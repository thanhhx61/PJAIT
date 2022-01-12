Imports Dao
Imports Services
Imports Services.Services
Imports Unity
Imports Unity.Mvc5
Public Class UnityConfig
    Public Shared Sub RegisterComponents()
        Dim container = New UnityContainer()
        container.RegisterType(GetType(IRepository(Of)), GetType(Repository(Of)))
        container.RegisterType(Of ITPL00010Service, TPL00010ServiceImpl)
        container.RegisterType(Of ITPL00020Service, TPL00020ServiceImpl)
        container.RegisterType(Of ITPL01040Service, TPL01040ServiceImpl)
        container.RegisterType(Of ITPL04020Service, TPL04020Servicelmpl)

        container.RegisterType(Of ITPL99010Service, TPL99010ServiceImpl)
        container.RegisterType(Of ITPL99020Service, TPL99020ServiceImpl)
        container.RegisterType(Of ITPL99040Service, TPL99040ServiceImpl)
        container.RegisterType(Of ITPL99050Service, TPL99050ServiceImpl)
        container.RegisterType(Of ICMN9000Service, CMN9000ServiceImpl)
        container.RegisterType(Of IBaseService, BaseServiceImpl)

        DependencyResolver.SetResolver(New UnityDependencyResolver(container))
    End Sub
End Class
