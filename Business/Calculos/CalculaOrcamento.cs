namespace MechTech.Business.Calculos
{
    public class CalculaOrcamento<T>
    {
        public T Calcula(CalculoBase<T> orcamento, T obj)
        {
            return orcamento.Calcula(obj);
        }

        public T Totaliza(CalculoBase<T> orcamento, T obj)
        {
            return orcamento.Totaliza(obj);
        }
    }
}
