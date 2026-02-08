using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public enum Role
    {
        Admin,
        Manager,
        Agent
    }

    public enum Permission
    {
        CreateLoan,
        ApproveLoan,
        ViewAll,
        ViewSelf
    }

    public class User
    {
        public Role Role { get; set; }
        public int UserId { get; set; }
        public int OwnerId { get; set; }
    }

    public class RbacService
    {
        public bool Authorize(User user, Permission permission, int resourceOwnerId)
        {
            if (user.Role == Role.Admin) return true;
            if (user.Role == Role.Manager && permission != Permission.ViewAll) return true;
            if (user.Role == Role.Agent && permission == Permission.ViewSelf)
                return user.UserId == resourceOwnerId;

            return false;
        }
    }

    [TestFixture]
    public class RbacServiceTests
    {
        [Test]
        public void AgentCanViewSelfOnly()
        {
            var user = new User { Role = Role.Agent, UserId = 1 };
            var service = new RbacService();

            Assert.That(service.Authorize(user, Permission.ViewSelf, 1), Is.True);
            Assert.That(service.Authorize(user, Permission.ViewSelf, 2), Is.False);
        }
    }

    class RoleBased_Access
    {
        static void Main() { }
    }
}
