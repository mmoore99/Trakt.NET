﻿namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Enums;
    using Lists;
    using System;

    /// <summary>Contains information about an item a Trakt user has liked, including the corresponding comment or list.</summary>
    public class TraktUserLikeItem : ITraktUserLikeItem
    {
        /// <summary>Gets or sets the UTC datetime, when the comment or list was liked.</summary>
        public DateTime? LikedAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this liked item contains.
        /// See also <seealso cref="TraktUserLikeType" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktUserLikeType Type { get; set; }

        /// <summary>
        /// Gets or sets the comment, if <see cref="Type" /> is <see cref="TraktUserLikeType.Comment" />.
        /// See also <seealso cref="ITraktComment" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktComment Comment { get; set; }

        /// <summary>
        /// Gets or sets the list, if <see cref="Type" /> is <see cref="TraktUserLikeType.List" />.
        /// See also <seealso cref="ITraktList" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktList List { get; set; }
    }
}
