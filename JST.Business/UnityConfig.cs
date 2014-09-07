using JST.DataAccess;
using Microsoft.Practices.Unity;

namespace JST.Business
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer unityContainer)
        {
            unityContainer.RegisterType<IAccountDataService, AccountDataService>();
            unityContainer.RegisterType<IAccountTypeDataService, AccountTypeDataService>();
            unityContainer.RegisterType<IWorkoutDataService, WorkoutDataService>();
            unityContainer.RegisterType<IWorkoutTypeDataService, WorkoutTypeDataService>();
        }
    }
}
