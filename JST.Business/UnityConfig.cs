using JST.DataAccess;
using Microsoft.Practices.Unity;

namespace JST.Business
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IExceptionDataService, ExceptionDataService>();
            unityContainer.RegisterType<IAccountDataService, AccountDataService>();
            unityContainer.RegisterType<IRoleDataService, RoleDataService>();
            unityContainer.RegisterType<ISessionDataService, SessionDataService>();
            unityContainer.RegisterType<IWorkoutDateDataService, WorkoutDateDataService>();
            unityContainer.RegisterType<IWorkoutDataService, WorkoutDataService>();
            unityContainer.RegisterType<IWorkoutTypeDataService, WorkoutTypeDataService>();
            unityContainer.RegisterType<IResultDataService, ResultDataService>();
        }
    }
}
