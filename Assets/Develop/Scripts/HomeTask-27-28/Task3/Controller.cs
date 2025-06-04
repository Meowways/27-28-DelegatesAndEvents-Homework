namespace Task3_2728
{
    public abstract class Controller
    {
        public void Update(float dealtaTime)
        {
            UpgradeLogic(dealtaTime);
        }

        protected abstract void UpgradeLogic(float dealtaTime);
    }
}