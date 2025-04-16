namespace RideShare.DAL.Configuration
{
    public class RolesSeedConstants
    {
        public static readonly Guid AdminRoleId = Guid.Parse("be2d2e92-f827-4058-aae8-f87be14b84e9");
        public static readonly Guid PassagerRoleId = Guid.Parse("3bac86d1-bb1d-41e3-ac0c-bd2f0058359e");
        public static readonly Guid DriverRoleId = Guid.Parse("83700286-0449-41c2-84c9-39f08e5f60b9");

        public static readonly string AdminRoleName = "Admin"; 
        public static readonly string PassagerRoleName = "Passager"; 
        public static readonly string DriverRoleName = "Driver"; 
    }
}
