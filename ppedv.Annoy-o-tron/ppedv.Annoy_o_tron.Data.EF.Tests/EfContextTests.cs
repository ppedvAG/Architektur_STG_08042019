using System;
using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Annoy_o_tron.Model;

namespace ppedv.Annoy_o_tron.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                Assert.IsFalse(con.Database.Exists());
                con.Database.Create();
                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_can_CRUD_Person()
        {
            var p = new Person() { Name = $"Fred_{Guid.NewGuid()}" };
            var newName = $"Barney_{Guid.NewGuid()}";
            using (var con = new EfContext())
            {
                //CREATE
                con.People.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //READ
                var loaded = con.People.Find(p.Id);
                Assert.AreEqual(p.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //READ
                var loaded = con.People.Find(p.Id);
                Assert.AreEqual(newName, loaded.Name);

                //DELETE
                con.People.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //READ
                var loaded = con.People.Find(p.Id);
                Assert.IsNull(loaded);
            }
        }

        [TestMethod]
        public void EfContext_can_save_Process()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new TypeRelay(typeof(Template), typeof(Daily)));
            var proc = fix.Create<Process>();

            //var proc = fix.Build<Process>().Without(x => x.Template).Create();

            using (var con = new EfContext())
            {
                //CREATE
                con.Processes.Add(proc);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Processes.Find(proc.Id);
                //Assert.IsNotNull(loaded);
                loaded.Should().NotBeNull();
                loaded.Should().BeEquivalentTo(proc, op =>
                 {
                     op.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation)).WhenTypeIs<DateTime>();
                     op.IgnoringCyclicReferences();
                     return op;
                 });
            }
        }

        [TestMethod]
        public void EfContext_delete_WorkItem_should_not_delete_Process()
        {
            var p = new Process();
            var w1 = new WorkItem() { Time = DateTime.Now };
            var w2 = new WorkItem() { Time = DateTime.Now };
            p.WorkItems.Add(w1);
            p.WorkItems.Add(w2);

            using (var con = new EfContext())
            {
                con.Processes.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.WorkItems.Find(w2.Id);
                loaded.Should().NotBeNull("INSERT cascade");

                con.WorkItems.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loadedWi = con.WorkItems.Find(w2.Id);
                loadedWi.Should().BeNull();

                var loadedP = con.Processes.Find(p.Id);
                loadedP.Should().NotBeNull("No DELETE cascade");
            }
        }


        [TestMethod]
        public void EfContext_delete_Process_should_delete_WorkItems()
        {
            var p = new Process();
            var w1 = new WorkItem() { Time = DateTime.Now };
            var w2 = new WorkItem() { Time = DateTime.Now };
            p.WorkItems.Add(w1);
            p.WorkItems.Add(w2);

            using (var con = new EfContext())
            {
                con.Processes.Add(p);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Processes.Find(p.Id);
                con.Processes.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                con.WorkItems.Find(w1.Id).Should().BeNull();
                con.WorkItems.Find(w2.Id).Should().BeNull();
            }
        }
        //todo mehr tests 
    }
}
