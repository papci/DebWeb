namespace DebWeb
{
    public static class LetsencryptGenerator
    {
        public static void GenerateCert( EnvSettings.SystemSettings systemSettings,EnvSettings.AppSettings appSettings)
        {
            $"sudo {systemSettings.LetsencryptPath}/letsencrypt-auto certonly -n --agree-tos --email {appSettings.UserEmail} --rsa-key-size 4096 --webroot --webroot-path {appSettings.GetWWWLE()} -d {string.Join(" -d ", appSettings.Dns)}".Bash();
        }

        public static string GetSslCertFullchain(string domainName)
        {
            return $"/etc/letsencrypt/live/{domainName}/fullchain.pem";
        }

         public static string GetSslKey(string domainName)
        {
            return $"/etc/letsencrypt/live/{domainName}/privkey.pem";
        }
    }
}