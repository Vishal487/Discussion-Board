using NUnit.Framework;
using Content;
using Networking;
using System.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Testing.Content
{
    [TestFixture]
    public class ContentModuleTesting
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void CSend_ChatSendingHiMsg_SerializedStringShouldMatchInputMsg()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            SendMessageData SampleData = _util.GenerateChatSendMsgData("Hello, How are you?",new int[]{1002},type:MessageType.Chat);
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.NewMessage, "Hello, How are you?", new int[]{ 1002 }, type: MessageType.Chat);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator(); 
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;
            
            _iContentClient.CSend(SampleData);

            var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Assert.AreEqual(receivedMessage.Message, SampleMsgData.Message);
                Assert.AreEqual(receivedMessage.Event, MessageEvent.NewMessage);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.FileData, SampleMsgData.FileData);
                Assert.AreEqual(receivedMessage.Starred, SampleMsgData.Starred);
                Assert.AreEqual(receivedMessage.ReplyThreadId, SampleMsgData.ReplyThreadId);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.ReceiverIds.Length, SampleMsgData.ReceiverIds.Length);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CSend_ChatSendingMsgWithNewline_SerializedStringShouldMatchInputMsg()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            SendMessageData SampleData = _util.GenerateChatSendMsgData("Hello, How are you?\n I am fine", new int[] { 1002 }, type: MessageType.Chat);
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.NewMessage, "Hello, How are you?\n I am fine", new int[] { 1002 }, type: MessageType.Chat);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;

            _iContentClient.CSend(SampleData);

            var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Assert.AreEqual(receivedMessage.Message, SampleMsgData.Message);
                Assert.AreEqual(receivedMessage.Event, MessageEvent.NewMessage);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.FileData, SampleMsgData.FileData);
                Assert.AreEqual(receivedMessage.Starred, SampleMsgData.Starred);
                Assert.AreEqual(receivedMessage.ReplyThreadId, SampleMsgData.ReplyThreadId);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.ReceiverIds.Length, SampleMsgData.ReceiverIds.Length);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CSend_ChatSendingMsgWithNullString_SerializedStringShouldMatchInputMsg()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            SendMessageData SampleData = _util.GenerateChatSendMsgData(null, new int[] { 1002 }, type: MessageType.Chat);
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.NewMessage, null, new int[] { 1002 }, type: MessageType.Chat);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;

            _iContentClient.CSend(SampleData);

            var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Assert.AreEqual(receivedMessage.Message, SampleMsgData.Message);
                Assert.AreEqual(receivedMessage.Event, MessageEvent.NewMessage);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.FileData, SampleMsgData.FileData);
                Assert.AreEqual(receivedMessage.Starred, SampleMsgData.Starred);
                Assert.AreEqual(receivedMessage.ReplyThreadId, SampleMsgData.ReplyThreadId);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.ReceiverIds.Length, SampleMsgData.ReceiverIds.Length);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CSend_ChatSendingHiMsgWithBroadcast_SerializedStringShouldMatchInputMsg()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            SendMessageData SampleData = _util.GenerateChatSendMsgData("Hello, How are you?\n I am fine", new int[] {}, type: MessageType.Chat);
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.NewMessage, "Hello, How are you?\n I am fine", new int[] {}, type: MessageType.Chat);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;

            _iContentClient.CSend(SampleData);

            var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Assert.AreEqual(receivedMessage.Message, SampleMsgData.Message);
                Assert.AreEqual(receivedMessage.Event, MessageEvent.NewMessage);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.FileData, SampleMsgData.FileData);
                Assert.AreEqual(receivedMessage.Starred, SampleMsgData.Starred);
                Assert.AreEqual(receivedMessage.ReplyThreadId, SampleMsgData.ReplyThreadId);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.ReceiverIds.Length, SampleMsgData.ReceiverIds.Length);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CSend_FileSendingValidFilePathToServer_SerializedStringShouldMatchFileData()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            string CurrentDirectory = Directory.GetCurrentDirectory() as string;
            string[] path = CurrentDirectory.Split(new string[] { "\\Testing" }, StringSplitOptions.None);
            string FilePath = path[0] + "\\Testing\\Content\\Test_File.pdf";
            var Filedata = new SendFileData(FilePath);
            SendMessageData SampleData = _util.GenerateChatSendMsgData(FilePath, new int[] { }, type: MessageType.File);
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.NewMessage, FilePath, new int[] { }, type: MessageType.File);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;
            _iContentClient.CSend(SampleData);
            var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Console.WriteLine(Filedata.fileName);
                Console.WriteLine(receivedMessage.Message);
                Assert.AreEqual(receivedMessage.Message, Filedata.fileName);
                Assert.AreEqual(receivedMessage.Event, MessageEvent.NewMessage);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.FileData.fileContent, Filedata.fileContent);
                Assert.AreEqual(receivedMessage.FileData.fileSize, Filedata.fileSize);
                Assert.AreEqual(receivedMessage.FileData.fileName, Filedata.fileName);
                Assert.AreEqual(receivedMessage.Starred, SampleMsgData.Starred);
                Assert.AreEqual(receivedMessage.ReplyThreadId, SampleMsgData.ReplyThreadId);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.MessageId, -1);
                Assert.AreEqual(receivedMessage.ReceiverIds.Length, SampleMsgData.ReceiverIds.Length);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CSend_InValidFilePath_ShouldThrowFileNotFoundException()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string FilePath = ".\\InvalidFile.pdf";
            SendMessageData SampleData = _util.GenerateChatSendMsgData(FilePath, new int[] { }, type: MessageType.File);
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.NewMessage, FilePath, new int[] { }, type: MessageType.File);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;

            FileNotFoundException ex = Assert.Throws<FileNotFoundException>(() => _iContentClient.CSend(SampleData));
            Assert.AreEqual("File "+FilePath+" not found", ex.Message);
        }

        [Test]
        public void CMarkStar_ClientShouldSendProperRequestToServer_SerializedStrMustHaveProperMarkstarReq()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            int MsgId = 10;
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.Star, "", new int[] {}, type: MessageType.Chat);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;

            _iContentClient.CMarkStar(MsgId);

            var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Assert.AreEqual(receivedMessage.Event, MessageEvent.Star);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.MessageId, MsgId);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void CDownload_SendingDownloadReqToServerWithInvalidMsgId_ShouldThrowArgumentException()
        {
            Utils _util = new Utils();
            int UserId = 1001;
            int MsgId = 10;
            string CurrentDirectory = Directory.GetCurrentDirectory() as string;
            string SavePath = CurrentDirectory + "\\SavedTestFile.pdf";
            MessageData SampleMsgData = _util.GenerateChatMessageData(MessageEvent.Download, SavePath, new int[] { }, type: MessageType.File);

            ISerializer _serializer = new Serializer();
            ContentClient _contentClient = ContentClientFactory.getInstance() as ContentClient;
            FakeCommunicator _fakeCommunicator = _util.GetFakeCommunicator();
            _contentClient.UserId = UserId;
            _contentClient.Communicator = _fakeCommunicator;
            IContentClient _iContentClient = _contentClient;

            ArgumentException ex = Assert.Throws<ArgumentException>(() => _iContentClient.CDownload(MsgId, SavePath));
            Assert.AreEqual("Message with given message ID not found", ex.Message);

            /*var sendSerializedMsg = _fakeCommunicator.GetSentData();
            var deserialized = _serializer.Deserialize<MessageData>(sendSerializedMsg);

            if (deserialized is MessageData)
            {
                var receivedMessage = deserialized as MessageData;
                Assert.AreEqual(receivedMessage.Message, SampleMsgData.Message);
                Assert.AreEqual(receivedMessage.Event, MessageEvent.Download);
                Assert.AreEqual(receivedMessage.Type, SampleMsgData.Type);
                Assert.AreEqual(receivedMessage.SenderId, UserId);
                Assert.AreEqual(receivedMessage.MessageId, MsgId);
                Assert.AreEqual(receivedMessage.FileData, null);
            }
            else
            {
                Assert.Fail();
            }*/
        }
    }
}