using System.Web;
using Hik.JTable.Repositories;
using Hik.JTable.Repositories.Memory;

namespace Hik.JTable.Sessions
{
    public static class RepositorySesssion
    {
        public static IRepositoryContainer GetRepository(RepositorySize size = RepositorySize.Medium, string repositoryKey = "common")
        {
            var sessionKey = "Repository_" + repositoryKey + "_" + size;

            if (HttpContext.Current.Session[sessionKey] == null)
            {
                HttpContext.Current.Session[sessionKey] = CreateRepository(size);
            }

            return HttpContext.Current.Session[sessionKey] as IRepositoryContainer;
        }

        private static IRepositoryContainer CreateRepository(RepositorySize size)
        {
            var studentCount = 16; //Default: Small
            switch (size)
            {
                case RepositorySize.Medium:
                    studentCount = 128;
                    break;
                case RepositorySize.Large:
                    studentCount = 1024;
                    break;
            }

            return new MemoryRepositoryContainer(new MemoryDataGenerator().Generate(studentCount));
        }
    }
}
