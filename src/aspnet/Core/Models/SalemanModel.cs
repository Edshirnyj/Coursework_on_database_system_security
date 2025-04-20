namespace Core.Models
{
    public class SalemanModel
    {
        public Guid SalemanId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public Guid PositionId { get; set; }

        private SalemanModel(Guid salemanId, string? name, string? surname, string? patronymic, Guid positionId)
        {
            SalemanId = salemanId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PositionId = positionId;
        }

        public static (SalemanModel SalemanModel, string Error) Create(Guid salemanId, string? name, string? surname, string? patronymic, Guid positionId)
        {
            string? error = ValidateInputs(name, surname, patronymic, positionId);
            if (!string.IsNullOrEmpty(error))
            {
                return (null!, error);
            }

            var salemanModel = new SalemanModel(salemanId, name, surname, patronymic, positionId);
            return (salemanModel, string.Empty);
        }

        private static string? ValidateInputs(string? name, string? surname, string? patronymic, Guid positionId)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name cannot be empty.";

            if (string.IsNullOrWhiteSpace(surname))
                return "Surname cannot be empty.";

            if (string.IsNullOrWhiteSpace(patronymic))
                return "Patronymic cannot be empty.";

            if (positionId == Guid.Empty)
                return "Position ID cannot be empty.";

            return string.Empty;
        }        
    }
}