using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entites
{
    [Table("type_contracts")]
    public class TypeContractEntity
    {
        [Column("type_contract_id")]
        public Guid TypeContractId { get; private set; } = Guid.NewGuid();

        [Column("name")]
        public string Name { get; private set; } = string.Empty;
    }
}