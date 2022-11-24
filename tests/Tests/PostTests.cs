using DocumentStorage.Core.DomainObjects;
using DocumentStorage.Domain.Models;
using System;
using Xunit;

namespace DocumentStorage.Tests
{
    public class PostTests
    {
        [Fact]
        public void Validate_LoggedUserExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Post(Guid.Empty, Guid.Empty, string.Empty, PostType.Post, DateTime.Now) 
            );
            Assert.Equal("Only logged users could post", ex.Message);
        }


        [Fact]
        public void Validate_ContentEmptyException()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Post(Guid.Empty, Guid.NewGuid(), string.Empty, PostType.Post, DateTime.Now)
            );
            Assert.Equal("Content could not be empty", ex.Message);
        }

        [Fact]
        public void Validate_ContentMaxLengthException()
        {
            var content = @"
Legolas lashed out with his sword, but an orc swung his club, and the blade of Legolas’ weapon collided with the clubs hide.
The blade pierced into the orcs flesh, and the orc yelped in pain.
The warrior was completely unprepared for Legolas’ wrath, and found himself lying at the feet of the elf.
Gimli felt rage course through his veins as he looked upon his friend.
He lunged forward and delivered a mighty blow to the knee of the orc.
The steel-toed boot of the half-ogre crushed the knee of the orc warrior.
Gimli leapt on top of the orc warrior, and began chopping off the orc’s legs.
“Legolas!” Gimli roared, as he held off the demon with a strong sword hand.
“Help me take down this one!” Gimli shouted as he ducked and weaved through the guardsmen and into the orc.";
            var ex = Assert.Throws<DomainException>(() =>
                new Post(Guid.Empty, Guid.NewGuid(), content, PostType.Post, DateTime.Now)
            );
            Assert.Equal("Content couldn't exceeds 777 characters", ex.Message);
        }

    }
}