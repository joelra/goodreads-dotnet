﻿using System.Threading.Tasks;
using Goodreads.Clients;
using Xunit;

namespace Goodreads.Tests
{
    public class TopicsEndpointsTests
    {
        private readonly IOAuthTopicsEndpoint TopicsEndpoint;

        public TopicsEndpointsTests()
        {
            TopicsEndpoint = Helper.GetAuthClient().Topics;
        }

        public class TheGetInfoMethods : TopicsEndpointsTests
        {
            [Fact]
            public async Task GetInfo()
            {
                const long topicId = 1;
                var topic = await TopicsEndpoint.GetInfo(topicId);

                Assert.Equal(topicId, topic.Id);
                Assert.NotEmpty(topic.Title);
            }

            [Fact]
            public async Task GetGroupFolder()
            {
                const long folderId = 338096;
                const long groupId = 189072;
                var topics = await TopicsEndpoint.GetTopics(folderId, groupId);

                Assert.NotNull(topics);
                Assert.NotEmpty(topics.List);
                Assert.All(topics.List, t => Assert.Equal(folderId, t.Folder.Id));
            }

            [Fact]
            public async Task GetUnreadGroupTopics()
            {
                const long groupId = 189072;
                var topics = await TopicsEndpoint.GetUnreadTopics(groupId);

                Assert.NotNull(topics);
                Assert.NotEmpty(topics.List);
            }
        }
    }
}
