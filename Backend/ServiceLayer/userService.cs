﻿using System;
using System.Reflection;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;
using log4net;

public class UserService
{
    public UserController userController;
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public UserService()
    {
        userController = new UserController();
    }

    /// <summary>
    ///  This method logs in an existing user.
    /// </summary>
    /// <param name="email">The email address of the user to login</param>
    /// <param name="password">The password of the user to login</param>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response login(String email, String password)
    {
        try
        {
            User user = userController.login(email, password);
            log.Info("user with email: " + email + " has logged in successfully");
            return new Response("{}", email);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method creates a new account. 
    /// </summary>
    /// <param name="email">The email of the new user</param>
    /// <param name="password">The password of the new user</param>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response createUser(String email, String password)
    {
        try
        {
            User user = userController.createUser(email, password);
            log.Info("user with email " + email + " was created successfully");
            return new Response(null, "{}");
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method logs out a logged in user. 
    /// </summary>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response logout(string email)
    {
        try
        {
            userController.logout(email);
            log.Info("user with email: " + email + "has logged out successfully");
            return new Response("{}", null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

    /// <summary>
    /// This method deletes the current account. 
    /// </summary>
    /// <returns>Json formatted string, where ErrorMessage = "ok" , unless an error occurs</returns>
    public Response deleteAccount(string email)
    {
        try
        {
            userController.deleteUser(email);
            log.Info("user with email: " + email + " has been deleted successfully");
            return new Response("{}", null);
        }
        catch (Exception e)
        {
            log.Debug(e.Message);
            return new Response(e.Message, null);
        }
    }

}
