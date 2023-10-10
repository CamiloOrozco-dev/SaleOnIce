using System.Linq.Expressions;

namespace SaleOnIce.Services.Helpers
{
    public static class EntityValidations<TEntity>
    {
        // Validación para verificar si una propiedad no es nula
        public static Func<TEntity, bool> NotNull(Expression<Func<TEntity, object>> propertySelector) =>
            entity => propertySelector.Compile()(entity) != null;

        // Validación para verificar si una propiedad es un entero
        public static Func<TEntity, bool> IsInteger(Expression<Func<TEntity, int>> propertySelector) =>
            entity => propertySelector.Compile()(entity) >= 0;

        // Validación para verificar si una propiedad es un entero no negativo
        public static Func<TEntity, bool> IsNonNegativeInteger(Expression<Func<TEntity, int>> propertySelector) =>
            entity => propertySelector.Compile()(entity) >= 0;

        // Ejemplos adicionales de validaciones:

        // Verifica si una propiedad es una cadena no nula ni vacía
        public static Func<TEntity, bool> NotNullOrEmpty(Expression<Func<TEntity, string>> propertySelector) =>
            entity => !string.IsNullOrEmpty(propertySelector.Compile()(entity));

        // Verifica si una propiedad es una fecha no nula y mayor que una fecha mínima
        public static Func<TEntity, bool> IsValidDate(Expression<Func<TEntity, DateTime>> propertySelector) =>
            entity => propertySelector.Compile()(entity) > DateTime.MinValue;

        // Verifica si una propiedad es un número decimal positivo
        public static Func<TEntity, bool> IsPositiveDecimal(Expression<Func<TEntity, decimal>> propertySelector) =>
            entity => propertySelector.Compile()(entity) > 0;

        // Verifica si una propiedad es un número de punto flotante válido
        public static Func<TEntity, bool> IsValidFloat(Expression<Func<TEntity, float>> propertySelector) =>
            entity => !float.IsNaN(propertySelector.Compile()(entity));

        // Verifica si una propiedad es un valor booleano verdadero
        public static Func<TEntity, bool> IsTrue(Expression<Func<TEntity, bool>> propertySelector) =>
            entity => propertySelector.Compile()(entity) == true;

        // Verifica si una propiedad es un valor booleano falso
        public static Func<TEntity, bool> IsFalse(Expression<Func<TEntity, bool>> propertySelector) =>
            entity => propertySelector.Compile()(entity) == false;

        // Verifica si una propiedad es un valor enum válido
        public static Func<TEntity, bool> IsValidEnum<TEnum>(Expression<Func<TEntity, TEnum>> propertySelector) where TEnum : Enum =>
            entity => Enum.IsDefined(typeof(TEnum), propertySelector.Compile()(entity));
    }

}
