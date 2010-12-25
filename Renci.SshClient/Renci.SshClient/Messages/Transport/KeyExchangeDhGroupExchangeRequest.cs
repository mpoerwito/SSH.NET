﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renci.SshClient.Messages.Transport
{
    [Message("SSH_MSG_KEX_DH_GEX_REQUEST", 34)]
    internal class KeyExchangeDhGroupExchangeRequest : Message
    {
        /// <summary>
        /// Gets or sets the minimal size in bits of an acceptable group.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public UInt32 Minimum { get; private set; }

        /// <summary>
        /// Gets or sets the preferred size in bits of the group the server will send.
        /// </summary>
        /// <value>
        /// The preferred.
        /// </value>
        public UInt32 Preferred { get; private set; }

        /// <summary>
        /// Gets or sets the maximal size in bits of an acceptable group.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public UInt32 Maximum { get; private set; }

        public KeyExchangeDhGroupExchangeRequest(uint minimum, uint preferred, uint maximum)
        {
            this.Minimum = minimum;
            this.Preferred = preferred;
            this.Maximum = maximum;
        }

        protected override void LoadData()
        {
            this.Minimum = this.ReadUInt32();
            this.Preferred = this.ReadUInt32();
            this.Maximum = this.ReadUInt32();
        }

        protected override void SaveData()
        {
            this.Write(this.Minimum);
            this.Write(this.Preferred);
            this.Write(this.Maximum);
        }
    }
}