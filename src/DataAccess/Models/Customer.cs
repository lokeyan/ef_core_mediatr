﻿namespace DataAccess.Models;

public class Customer
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Subscription.Level SubscriptionLevel { get; set; }

    public virtual Subscription Subscription { get; set; }
}
