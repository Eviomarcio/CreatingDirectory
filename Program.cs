using System;
using System.IO;

namespace CreatingDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderName = "pasta_raiz";
            var subFolderName = "sub_pasta_raiz";
            var subFolderNameStatic = "subpasta_unsingstatic";

            var directorInfoSubFolder = new DirectoryInfo(subFolderName);

            if (Directory.Exists(subFolderName) || !directorInfoSubFolder.Exists)
            {
                //Criação de diretorio statico
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName); 
                }
                
                if (!Directory.Exists($"{folderName}//{subFolderNameStatic}"))
                {
                    Directory.CreateDirectory(subFolderNameStatic);
                }
                
                //criação de diretorio por estancia 
                directorInfoSubFolder.Create();

                //Movendo diretorio por classe estanciada
                if (!Directory.Exists($"{folderName}//{subFolderName}"))
                {
                    directorInfoSubFolder.MoveTo($"{folderName}//{subFolderName}");
                }
                else
                {
                    Directory.Delete($@"{subFolderName}");
                }

                //Movendo diretorio por classe estatica
                if (!Directory.Exists($"{folderName}//{subFolderNameStatic}"))
                {
                    Directory.Move(subFolderNameStatic, @$"{folderName}\{subFolderNameStatic}");
                }
            }

            var name = directorInfoSubFolder.Name;
            var parent = directorInfoSubFolder.Parent;
            var root = directorInfoSubFolder.Root;
            var exists = directorInfoSubFolder.Exists;

            //Percorrer os diretorios
            foreach (var directory in Directory.GetDirectories(folderName))
            {
                Console.WriteLine(directory);
            }

            //Deletando diretorio
            if (Directory.Exists($@"{folderName}\{subFolderName}"))
            {
                Directory.Delete($@"{folderName}\{subFolderName}");
            }

            Console.Read();
        }
    }
}
