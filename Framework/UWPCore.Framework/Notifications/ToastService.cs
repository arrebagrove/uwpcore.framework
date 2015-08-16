﻿using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace UWPCore.Framework.Notifications
{
    /// <summary>
    /// Service class for toast notifications.
    /// </summary>
    /// <remarks>
    /// After the creation of a toast, the Tag, Group, ExpirationTime or SuppressPopus can be configured.
    /// </remarks>
    public class ToastService : IToastService
    {
        /// <summary>
        /// The text node.
        /// </summary>
        private const string TEXT_NODE = "text";

        /// <summary>
        /// The image node.
        /// </summary>
        private const string IMAGE_NODE = "image";

        /// <summary>
        /// The launch attribute to identify the notification when the app is launched via a toast.
        /// </summary>
        private const string LAUNCH_ATTRIBUTE = "launch";

        /// <summary>
        /// The source attribute for images.
        /// </summary>
        private const string SRC_ATTRIBUTE = "src";

        public ToastNotification CreateToastText01(string content, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastText01;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // content
            var text = xml.CreateTextNode(content);
            elements[0].AppendChild(text);
            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastText02(string title, string content, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastText02;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // title
            var text = xml.CreateTextNode(title);
            elements[0].AppendChild(text);

            // content
            text = xml.CreateTextNode(content);
            elements[1].AppendChild(text);

            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastText03(string title, string content, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastText03;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // title
            var text = xml.CreateTextNode(title);
            elements[0].AppendChild(text);

            // content
            text = xml.CreateTextNode(content);
            elements[1].AppendChild(text);

            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastText04(string title, string content1, string content2, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastImageAndText04;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // title
            var text = xml.CreateTextNode(title);
            elements[0].AppendChild(text);

            // content1
            text = xml.CreateTextNode(content1);
            elements[1].AppendChild(text);

            // content2
            text = xml.CreateTextNode(content2);
            elements[2].AppendChild(text);

            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastImageAndText01(string image, string content, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastImageAndText01;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // image
            var toastImageAttributes = xml.GetElementsByTagName(IMAGE_NODE);
            ((XmlElement)toastImageAttributes[0]).SetAttribute(SRC_ATTRIBUTE, image);

            // content
            var text = xml.CreateTextNode(content);
            elements[0].AppendChild(text);

            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastImageAndText02(string image, string title, string content, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastImageAndText02;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // image
            var toastImageAttributes = xml.GetElementsByTagName(IMAGE_NODE);
            ((XmlElement)toastImageAttributes[0]).SetAttribute(SRC_ATTRIBUTE, image);

            // title
            var text = xml.CreateTextNode(title);
            elements[0].AppendChild(text);

            // content
            text = xml.CreateTextNode(content);
            elements[1].AppendChild(text);

            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastImageAndText03(string image, string title, string content, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastImageAndText03;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // image
            var toastImageAttributes = xml.GetElementsByTagName(IMAGE_NODE);
            ((XmlElement)toastImageAttributes[0]).SetAttribute(SRC_ATTRIBUTE, image);

            // title
            var text = xml.CreateTextNode(title);
            elements[0].AppendChild(text);

            // content
            text = xml.CreateTextNode(content);
            elements[1].AppendChild(text);

            return new ToastNotification(xml);
        }

        public ToastNotification CreateToastImageAndText04(string image, string title, string content1, string content2, string arg = null)
        {
            // build toast
            var template = ToastTemplateType.ToastImageAndText04;
            var xml = ToastNotificationManager.GetTemplateContent(template);
            var elements = xml.GetElementsByTagName(TEXT_NODE);

            // launch arg
            if (arg != null)
                xml.DocumentElement.SetAttribute(LAUNCH_ATTRIBUTE, arg);

            // image
            var toastImageAttributes = xml.GetElementsByTagName(IMAGE_NODE);
            ((XmlElement)toastImageAttributes[0]).SetAttribute(SRC_ATTRIBUTE, image);

            // title
            var text = xml.CreateTextNode(title);
            elements[0].AppendChild(text);

            // content1
            text = xml.CreateTextNode(content1);
            elements[1].AppendChild(text);

            // content2
            text = xml.CreateTextNode(content2);
            elements[2].AppendChild(text);

            return new ToastNotification(xml);;
        }

        public void Show(ToastNotification toast)
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(toast);
        }

        public void ClearHistory()
        {
            ToastNotificationManager.History.Clear();
        }

        public void RemoveGroupeFromHistory(string group)
        {
            ToastNotificationManager.History.RemoveGroup(group);
        }

        public void RemoveFromHistory(string tag)
        {
            ToastNotificationManager.History.Remove(tag);
        }

        public void RemoveFromHistory(string tag, string group)
        {
            ToastNotificationManager.History.Remove(tag, group);
        }
    }
}