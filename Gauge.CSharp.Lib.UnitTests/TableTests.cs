namespace Gauge.CSharp.Lib.UnitTests
{
    [TestFixture]
    public class TableTests
    {
        [Test]
        public void ShouldBeAbleToAccessRowValuesUsingColumnNames()
        {
            var headers = new List<string> { "foo", "bar" };
            var table = new Table(headers);
            table.AddRow(new List<string> { "foo_val", "bar_val" });
            table.AddRow(new List<string> { "foo_val1", "bar_val1" });

            Assert.Multiple(() =>
            {
                Assert.That(table.GetTableRows()[0].GetCell("foo"), Is.EqualTo("foo_val"));
                Assert.That(table.GetTableRows()[0].GetCell("bar"), Is.EqualTo("bar_val"));
                Assert.That(table.GetTableRows()[1].GetCell("foo"), Is.EqualTo("foo_val1"));
                Assert.That(table.GetTableRows()[1].GetCell("bar"), Is.EqualTo("bar_val1"));
                Assert.That(table.GetTableRows()[1].GetCell("bar1"), Is.EqualTo(""));
                Assert.That(table.GetTableRows()[0].ToString(), Is.EqualTo("TableRow: cells: [foo = foo_val, bar = bar_val] "));
            });
        }

        [Test]
        public void ShouldGetEmptyListColumnValuesForInvalidColumnName()
        {
            var headers = new List<string> { "foo", "bar" };
            var table = new Table(headers);
            table.AddRow(new List<string> { "foo_val", "bar_val" });
            table.AddRow(new List<string> { "foo_val1", "bar_val1" });

            var columnValues = table.GetColumnValues("baz");

            Assert.That(columnValues, Is.Empty);
        }

        [Test]
        public void ShouldGetTableAsMarkdownString()
        {
            var headers = new List<string> { "foo", "bar_with_big_header" };
            var table = new Table(headers);
            table.AddRow(new List<string> { "foo_val", "bar_val" });
            table.AddRow(new List<string> { "foo_val1", "bar_val1" });

            const string expected = "|foo     |bar_with_big_header|\n" +
                                    "|--------|-------------------|\n" +
                                    "|foo_val |bar_val            |\n" +
                                    "|foo_val1|bar_val1           |";

            Assert.That(table.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ShouldGetValuesForGivenColumnName()
        {
            var headers = new List<string> { "foo", "bar" };
            var table = new Table(headers);
            table.AddRow(new List<string> { "foo_val", "bar_val" });
            table.AddRow(new List<string> { "foo_val1", "bar_val1" });

            var columnValues = table.GetColumnValues("foo").ToList();

            Assert.That(columnValues, Has.Count.EqualTo(2));
            Assert.That(columnValues, Does.Contain("foo_val"));
            Assert.That(columnValues, Does.Contain("foo_val1"));
        }
    }
}