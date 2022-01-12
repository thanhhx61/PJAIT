$(document).ready(function () {
    $(function () {
        var classes = {
            cssActive: 'active',
            iconCollapse: 'fa-chevron-left',
            iconExpand: 'fa-chevron-right',
            iconFont: 'fas',
            container: 'menu-container'
        },
            selectors = {},
            config = {
                animationSpeed: 'fast'
            };

        for (var className in classes) {
            selectors[className] = '.' + classes[className];
        }

        // Close
        function slideUp($icon) {
            $icon.removeClass(classes.iconCollapse).
                addClass(classes.iconExpand);
            $icon.parent().next().slideUp(config.animationSpeed);
        }

        // Open
        function slideDown($icon) {
            $icon.removeClass(classes.iconExpand).
                addClass(classes.iconCollapse);
            $icon.parent().next().slideDown(config.animationSpeed);
        }

        $(selectors.container).find(".menu_main").click(function (ev) {
            ev.preventDefault();
            var id = $(this)[0].id;
            var icons = $(this).find(".fa");
            var $ul = $("#ul_" + id);
            if (icons.length > 0) {
                var $icon = $(icons[0]);
                if ($icon.hasClass(classes.iconCollapse)) {
                    slideUp($icon);
                    $ul.empty();
                } else if ($icon.hasClass(classes.iconExpand)) {
                    var url = "/TPL00020/getProgram";
                    var token = $("input[name=__RequestVerificationToken]").val();
                    var sendData = {
                        "MenuId": id,
                        __RequestVerificationToken: token
                    };
                    var result = ajaxPost(url, sendData);
                    result.done(function (response) {
                        var index = 0;
                        $ul.empty();
                        for (index = 0; index < response.length; index++) {
                            var res = response[index];
                            if ($ul !== null) {
                                var $li = $('<li></li>');
                                var $link = $('<a class="menu-item" href="javascript:;" data-url="' + res.MenuUrl +'"></a>');
                                //$link.prop("href", res.MenuUrl);
                                $link.text(res.MenuName);
                                $li.append($link);
                                $ul.append($li);
                            }
                        }
                        slideDown($icon);
                    });
                }

            }
        });

        // link menu
        var listWindowOpened = [];
        $(".menu-container").on("click", ".menu-item", function () {
            var url = $(this).attr("data-url");
            var listWindowOpenedClone = [];
            for (var i = 0; i < listWindowOpened.length; i++) {
                if (typeof listWindowOpened[i].location.href !== "unknown" && typeof listWindowOpened[i].location.href !== "undefined"
                    && listWindowOpened[i].location.href && listWindowOpened[i].location.href.indexOf(url) !== -1) {
                    listWindowOpened[i].close();
                } else {
                    listWindowOpenedClone.push(listWindowOpened[i]);
                }
            }
            listWindowOpened = listWindowOpenedClone;
            listWindowOpened.push(window.open(url, "_blank"));
        });

        function scrollActiveMenuItemIntoView() {
            var $active = $(selectors.container + ' ' + selectors.cssActive);

            $(selectors.container).animate({
                scrollTop: $active.offset().top
            });
        }

        function expandMenuItems() {

            function expandMenuItemsHelper($li) {

                var $collapsedIcon = $li.children().find(selectors.iconFont).first();

                if ($collapsedIcon.length) {
                    slideDown($collapsedIcon);
                }

                if ($li.parent().closest('li').length) {
                    expandMenuItemsHelper($li.parent().closest('li').first());
                }
            }

            expandMenuItemsHelper($(selectors.container + ' ' + selectors.cssActive));
        }

        // logout
        $("#logout").click(function () {
            localStorage.removeItem("tab-opened");
            ajaxNoReply("/TPL00020/Logout").done(function () {
                window.location.href = "/TPL00010";
            })
        });

        //$("#btn-download").click(function () {
        //    var token = $("input[name=__RequestVerificationToken]").val();
        //    var sendData = {
        //        "MenuId": "1111",
        //        __RequestVerificationToken: token
        //    };
        //    $.fileDownload("/TPL00020/DownloadPdf", {
        //        httpMethod: "POST",
        //        data: sendData,
        //        successCallback: function (url) {
        //            unScreenLock();
        //        },
        //        failCallback: function (responseHtml, url, error) {
        //            unScreenLock();
        //            try {
        //                var response = JSON.parse(responseHtml);
        //                setMessageInfo(response.Message);
        //                typeError = response.Data.TypeError;
        //            } catch (e) {
        //                //TODO
        //            }
        //        }
        //    });
        //});


        //$("#btn-download-save").click(function () {
        //    var token = $("input[name=__RequestVerificationToken]").val();
        //    var sendData = {
        //        "MenuId": "1111",
        //        __RequestVerificationToken: token
        //    };
        //    var result = ajaxPost("/TPL00020/DownloadPdfSaveFile", sendData);
        //    result.done(function (response) {
        //        var fileName = response.fileName;
               
        //    });
        //});


        //function clickPdf(el) {
        //    el.click(function (e) {
        //        e.preventDefault();
        //        window.location.href = res;
        //    });
        //};
       

        expandMenuItems();

        setTimeout(function () {
            $(selectors.container).show();
            scrollActiveMenuItemIntoView();
        }, 200);
    });
});

function handleAfterCodeChange(code) {
    //TODO
}

function handleAfterCustomCodeChange(code) {
    //TODO
}

function handleAfterOrderNoChange(code) {
    //TODO
}

function handleAfterPaperCodeChange(code) {
    //TODO
}

function handleAfterDepartmentICChange(code) {
    //TODO
}

function handleAfterPersonCodeChange(code) {
    //TODO
}


