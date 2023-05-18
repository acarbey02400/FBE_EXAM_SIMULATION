namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int operationClaimId { get; set; }
        public bool isDeleted { get; set; }
    }
}
