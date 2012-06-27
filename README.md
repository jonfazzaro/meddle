![](http://dl.dropbox.com/u/3057627/meddle/meddle-logo-small.png)

# A featherweight way to add your custom logic to Entity Framework's SaveChanges operation.

## Are you the worst?

Are you the resident genius on your team? Do you wrap wrappers in wrappers and frame frameworks in frameworks? Have you ignored/obscured whole swaths of .NET because your application is a special, special unicorn? Well, I've got some bad news. You're the worst.

As for the rest of you, come with me. We're going to painlessly add some business logic to an Entity Framework model.

## EF and Meddle
Meddle is a set of interfaces that, when implemented by your existing generated entity classes, ensure that your custom code is run before any changes can be committed to storage. Your consuming code (and the other nerds on your team writing that consuming code) don't have to change a thing about how they are already using your entities. Unless they're totally doing it wrong like a bunch of jerks.

Anyway. Go [add Meddle to your project via NuGet](http://nuget.org/packages/Meddle), and let's begin.

## First, Implement *IWork*

If you don't already have a partial class definition for your *ObjectContext* or *DbContext*, make one. Then, use it to implement Meddle's *IWork* interface, almost exactly like this:

<pre>
using System.Collections.Generic;
using System.Data.Objects;
using Meddle;
using Meddle.EntityFramework;

namespace SpecialSpecialUnicorn
{
    public partial class SpecialUnicornEntities : IWork
    {
        public override int SaveChanges(SaveOptions options)
        {
            Meddler.Meddle(this); // here's where the meddle happens \m/
            return base.SaveChanges(options);
        }

        public IEnumerable<IAddable > Added
        {
            get { return this.GetAdded(); }
        }

        public IEnumerable<IDeletable > Deleted
        {
            get { return this.GetDeleted(); }
        }

        public IEnumerable<IUpdatable > Updated
        {
            get { return this.GetUpdated(); }
        }
    }
}
</pre>

In fact, you could just copy and paste that into a new .cs file, change the namespace and class name, and be done with it. 

And then?

## Then Implement *IAddable*, *IUpdatable*, or *IDeletable*

This next part is the meaningful, non-copy-and-paste part that's really going to be up to you and your application. But here are a few examples.

Meddle's *IAddable*, *IUpdatable*, and *IDeletable* interfaces respectively provide **OnAdding**, **OnUpdating**, and **OnDeleting** methods for your entity's partial class to implement. As the naming would suggest, this is where you do your custom unicorn-type things to make your model sing and dance:

<pre>
public partial class Product : IDeletable , IAddable
{
    public void OnDeleting()
    {
        if (this.PurchaseOrderDetails.Any())
            throw new ApplicationException(
                "This product is a special unicorn and it cannot be deleted." );
    }

    public void OnAdding()
    {
        if (UserPreferences.NoDuplicateProductNames)
        {
            using (context as new SpecialUnicornEntities())
            {
                if (context.Products.Any(p => p.Name.Equals(this.Name)))
                {
                    var message = "A product with the same name already exists.";
    
                    if (UserPreferences.ErrorMessageIntensity == ErrorMessageIntensity.Abusive)
                        message += " Be more creative next time. Loser.";
    
                    throw new ApplicationException(message);
                }
            }
        }
    }
}
</pre>
  
You can also quietly correct user input before it gets saved:

<pre>
public partial class Employee : IUpdatable
{
    public void OnUpdating()
    {
        // employee titles must always be in title case!
        this.Title =
            Thread.CurrentThread.CurrentCulture
            .TextInfo.ToTitleCase(this.Title);
    }
}
</pre>

And that's about it--nothing non-standard for the other devs to learn or work around, and no one is ever going to put one over on your data again. Not through your model, anyway.
