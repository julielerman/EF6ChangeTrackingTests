using EF6Samurai.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samurais;
using System.Data.Entity;

namespace Tests
{
  [TestClass]
  public class EF6BehaviorTests
  
  {
    public EF6BehaviorTests() {
      Database.SetInitializer(new NullDatabaseInitializer<SamuraiContext>());
    }
   

    [TestMethod]
    public void ModifiedStateWillGetChangedToAdded() {
      var samurai = new Samurai();
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Modified;
        context.Samurais.Add(samurai);
        Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void UnchangedStateWillGetChangedToAdded() {
      var samurai = new Samurai();
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Unchanged;
        context.Samurais.Add(samurai);
        Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void AddedStateWillGetChangedToUnchanged() {
      var samurai = new Samurai();
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Added;
        context.Samurais.Attach(samurai);
        Assert.AreEqual(EntityState.Unchanged, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void AddedStateWillGetChangedToDetachedWhenRemoved() {
      var samurai = new Samurai();
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Added;
        context.Samurais.Remove(samurai);
        Assert.AreEqual(EntityState.Detached, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void DeletedStateWillGetChangedToAdded() {
      var samurai = new Samurai();
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Deleted;
        context.Samurais.Add(samurai);
        Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void ModifiedStateChildWillGetChangedToAdded() {
      var samurai = new Samurai();
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Modified;
        context.Samurais.Add(samurai);
        Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void UnchangedStateChildWillGetChangedTo_ThisIsReallySmartActually_Modified() {
      var samurai = new Samurai();
      var quote = new Quote();
      samurai.Quotes.Add(quote);
      using (var context = new SamuraiContext()) {
        context.Entry(quote).State = EntityState.Unchanged;
        context.Samurais.Add(samurai);
        Assert.AreEqual(EntityState.Modified, context.Entry(quote).State);
      }
    }

    [TestMethod]
    public void AddedStateChildWillNotGetChangedToUnchanged() {
      var samurai = new Samurai();
      var quote = new Quote();
      samurai.Quotes.Add(quote);
      using (var context = new SamuraiContext()) {
        context.Entry(quote).State = EntityState.Added;
        context.Samurais.Attach(samurai);
        Assert.AreEqual(EntityState.Added, context.Entry(quote).State);
      }
    }

    [TestMethod]
    public void AddedStateChildWillGetChangedToDetachedWhenRemoved() {
      var samurai = new Samurai();
      var quote = new Quote();
      samurai.Quotes.Add(quote);
      using (var context = new SamuraiContext()) {
        context.Samurais.Attach(samurai); //<--this makes them both unchanged
        context.Entry(quote).State = EntityState.Added;
        context.Samurais.Remove(samurai);
        Assert.AreEqual(EntityState.Detached, context.Entry(quote).State);
      }
    }

    [ExpectedException(typeof(System.InvalidOperationException))]
    [TestMethod]
    public void DeletedStateChildWillThrowWhenAttemptingToChangeToAdded() {
      var samurai = new Samurai();
      var quote = new Quote();
      samurai.Quotes.Add(quote);
      using (var context = new SamuraiContext()) {
        context.Entry(quote).State = EntityState.Deleted;
        context.Samurais.Add(samurai);
        Assert.AreEqual(EntityState.Added, context.Entry(quote).State);
        //this will throw: "Adding a relationship with an entity which is in the Deleted state is not allowed."
      }
    }

  }
}