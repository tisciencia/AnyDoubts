using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyDoubts.Infra.SimpleMail.Transport
{
    public class EmailTransportConfiguration
    {
        //private static const string PROPERTIES_FILE = "fluent-mail-api.properties";
        //private static const string KEY_SMTP_SERVER = "smtp.server";
        //private static const string KEY_AUTH_REQUIRED = "auth.required";
        //private static const string KEY_USE_SECURE_SMTP = "use.secure.smtp";
        //private static const string KEY_USERNAME = "smtp.username";
        //private static const string KEY_PASSWORD = "smtp.password";

        //private static string smtpServer = "";
        //private static bool authenticationRequired = false;
        //private static bool useSecureSmtp = false;
        //private static string username = null;
        //private static string password = null;

        //static {
        //    Properties properties = loadProperties();

        //    String smtpServer = properties.getProperty(KEY_SMTP_SERVER);
        //    boolean authenticationRequired = Boolean
        //            .parseBoolean(KEY_AUTH_REQUIRED);
        //    boolean useSecureSmtp = Boolean.parseBoolean(KEY_USE_SECURE_SMTP);
        //    String username = properties.getProperty(KEY_USERNAME);
        //    String password = properties.getProperty(KEY_PASSWORD);

        //    configure(smtpServer, authenticationRequired, useSecureSmtp, username,
        //            password);
        //}
	
        //private static Properties loadProperties() {
        //    Properties properties = new Properties();

        //    InputStream inputStream = EmailTransportConfiguration.class
        //            .getResourceAsStream(PROPERTIES_FILE);

        //    if (inputStream == null) {
        //        inputStream = EmailTransportConfiguration.class.getResourceAsStream("/" + PROPERTIES_FILE);
        //    }

        //    try {
        //        properties.load(inputStream);
        //    } catch (Exception e) {
        //        // Properties file not found, no problem.
        //    }

        //    return properties;
        //}

        ///**
        // * Configure mail transport to use the specified SMTP server. Because this
        // * configuration mode does not require to inform username and password, it
        // * assumes that authentication and secure SMTP are not required.
        // * 
        // * @param smtpServer
        // *            The SMTP server to use for mail transport. To use a specific
        // *            port, user the syntax server:port.
        // */
        //public static void configure(String smtpServer) {
        //    configure(smtpServer, false, false, null, null);
        //}

        ///**
        // * @param smtpServer
        // *            The SMTP server to use for mail transport. To use a specific
        // *            port, user the syntax server:port.
        // * @param authenticationRequired
        // *            Informs if mail transport needs to authenticate to send mail
        // *            or not.
        // * @param useSecureSmtp
        // *            Use secure SMTP to send messages.
        // * @param username
        // *            The SMTP username.
        // * @param password
        // *            The SMTP password.
        // */
        //public static void configure(String smtpServer,
        //        boolean authenticationRequired, boolean useSecureSmtp,
        //        String username, String password) {
        //    EmailTransportConfiguration.smtpServer = smtpServer;
        //    EmailTransportConfiguration.authenticationRequired = authenticationRequired;
        //    EmailTransportConfiguration.useSecureSmtp = useSecureSmtp;
        //    EmailTransportConfiguration.username = username;
        //    EmailTransportConfiguration.password = password;
        //}

        //public String getSmtpServer() {
        //    return smtpServer;
        //}

        //public boolean isAuthenticationRequired() {
        //    return authenticationRequired;
        //}

        //public String getUsername() {
        //    return username;
        //}

        //public String getPassword() {
        //    return password;
        //}

        //public boolean useSecureSmtp() {
        //    return useSecureSmtp;
        //}
    }
}
