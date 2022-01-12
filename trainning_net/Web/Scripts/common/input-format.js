/*
init all element when load page
----------------------------------------
khởi tạo tất cả element khi tải trang
*/
initNumerInput('.ct-input-number');

/*
Init manual the element inputNumber by object, id, class
obj can be element or jquery of selector
----------------------------------------
Khởi tạo thủ công các element, đối số có thể là object(Dom), hoặc bộ chọn jquery
*/
function initNumerInput(obj) {
    if (obj && typeof obj === 'object') {
        if (!obj.hasOwnProperty('formattedValue')) {
            initDetailNumerInput(obj);
            obj.formattedValue = obj.value;
        } else {
            var elemValue = obj.value;
            var formatedValue = obj.formattedValue;
            if (elemValue !== formatedValue) {
                initDetailNumerInput(obj);
            }
        }
    } else if (obj && typeof obj === 'string') {
        $(obj).toArray().forEach(function (element) {
            if (!element.hasOwnProperty('formattedValue')) {
                initDetailNumerInput(element);
                element.formattedValue = element.value;
            } else {
                var elemValue = element.value;
                var formatedValue = element.formattedValue;
                if (elemValue !== formatedValue) {
                    initDetailNumerInput(element);
                }
            }
        });
    }
}

/*
init element's detal by attributes
----------------------------------------
khởi chi tiết của input dựa trên các đặct tính
*/
function initDetailNumerInput(element) {
    var formatedElement = new Cleave(element, {
        numeral: true,
        numeralThousandsGroupStyle: element.getAttribute("numeralThousandsGroupStyle"),
        numeralPositiveOnly: element.getAttribute("numeralPositiveOnly") === "True" ? true : false,
        numeralIntegerScale: parseInt(element.getAttribute("numeralIntegerScale")),
        numeralDecimalScale: parseInt(element.getAttribute("numeralDecimalScale"))
        //...going to develop in the future
    });
    //pading right for decimal part
    if (element.value && formatedElement.properties.numeralDecimalScale > 0) {
        var arrNumber = element.value.split(".");
        var intPart = arrNumber[0];
        var decPart = arrNumber.length > 1 ? arrNumber[1] : "";
        element.value = intPart + "." + decPart.padEnd(formatedElement.properties.numeralDecimalScale, "0");
    }
    element.formatedElement = formatedElement;

    return formatedElement;
}

/*
Hàm này sử dụng để thăm dò và kiểm tra xem có cần format không
nó được gọi sau khi thay đổi value bằng js
*/
function pollInitNumerInput() {
    initNumerInput('.ct-input-number');
}

$(".ct-input-number").on("focusin", function (event) {
    var formatedElement = event.target.formatedElement;
    event.target.value = formatedElement.getRawValue();
    //event.target.select();
});

$(".ct-input-number").on("focusout", function (event) {
    var formatedElement = event.target.formatedElement;
    var elemValue = event.target.value;
    var notNumberPattern = /^(\-\.{1}|\.$|[\-]$)/;
    if (notNumberPattern.test(elemValue)) {
        formatedElement.setRawValue("");
    } else {
        initDetailNumerInput(event.target);
        event.target.formattedValue = event.target.value;
    }
});

/*
Get object's raw value
----------------------------------------
Trả về dữ liệu ở dạng nguyên thủy (chưa format)
*/
function getRawValue(obj) {
    var rawValue;
    if (obj && typeof obj === 'object') {
        rawValue = obj.formatedElement.getRawValue();
    } else if (obj && typeof obj === 'string') {
        rawValue = $(obj).get(0).formatedElement.getRawValue();
    }
    return rawValue;
}
