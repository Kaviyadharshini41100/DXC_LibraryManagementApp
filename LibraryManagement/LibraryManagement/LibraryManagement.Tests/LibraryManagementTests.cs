using Moq;
using FluentAssertions;
namespace LibraryManagement.Tests
{
    public class Tests
    {
        [Test]
        public void AddStudent_WhenCalled_ReturnsValues()
        {
            var add = new Mock<IBook>();
            add.Setup(x => x.AddStudent()).Returns(1);
            var result = add.Object.AddStudent();
            result.Should().Be(1); 
            
        }
        [Test]
        public void AddBook_WhenCalled_ReturnsValues()
        {
            var add = new Mock<IBook>();
            add.Setup(x => x.AddBook()).Returns(1);
            var result = add.Object.AddBook();
            result.Should().Be(1);

        }
        [Test]
        public void EditStudent_WhenCalled_ReturnsValues()
        {
            var edit = new Mock<IBook>();
            edit.Setup(x => x.EditStudent()).Returns(1);
            var result = edit.Object.EditStudent();
            result.Should().Be(1);

        }
        [Test]
        public void EditBook_WhenCalled_ReturnsValues()
        {
            var edit = new Mock<IBook>();
            edit.Setup(x => x.EditBook()).Returns(1);
            var result = edit.Object.EditBook();
            result.Should().Be(1);

        }
        [Test]
        public void DeleteStudent_WhenCalled_ReturnsValues()
        {
            var del = new Mock<IBook>();
            del.Setup(x => x.DeleteStudent()).Returns(1);
            var result = del.Object.DeleteStudent();
            result.Should().Be(1);

        }
        [Test]
        public void DeleteBook_WhenCalled_ReturnsValues()
        {
            var del = new Mock<IBook>();
            del.Setup(x => x.DeleteBook()).Returns(1);
            var result = del.Object.DeleteBook();
            result.Should().Be(1);

        }


    }
}