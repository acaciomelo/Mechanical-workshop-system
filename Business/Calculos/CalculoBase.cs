namespace MechTech.Business.Calculos
{
    public class CalculoBase<T>
    {
        public virtual T Calcula(T obj)
        {
            return obj;
        }

        public virtual T Totaliza(T obj)
        {
            return obj;
        }
    }
}
