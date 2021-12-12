namespace SecretAdmin.Features.Program
{
    public static class ArgumentsManager
    {
        /*
         * Arguments:
         * --reconfigure -r
         * --config <filename> -c
         * --no-logs -nl
         * --simple-output -so
         */

        public static Args GetArgs(string[] args)
        {
            var ret = new Args();
            
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--reconfigure" or "-r":
                        ret.Reconfigure = true;
                        break;
                    case "--config" or "-c" when args.Length > i + 1:
                        i++;
                        ret.Config = args[i];
                        break;
                    case "--no-logs" or "-nl":
                        ret.Logs = false;
                        break;
                    case "--simple-output" or "-so":
                        ret.SimpleOutput = true;
                        break;
                }
            }

            return ret;
        }

        public class Args
        {
            public bool Reconfigure = false;
            public string Config = "default.yml";
            public bool Logs = true;
            public bool SimpleOutput = false;
        }
    }
}