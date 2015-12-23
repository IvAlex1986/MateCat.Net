using MateCat.Net.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MateCat.Net.Models
{
    /// <summary>
    /// The metadata for the created project.
    /// </summary>
    [DataContract]
    public class Project
    {
        /// <summary>
        /// Return the unique id of the project.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id_project")]
        public Int32 Id { get; set; }

        /// <summary>
        /// Return the password of the project.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataMember(Name = "project_pass")]
        public String Password { get; set; }

        /// <summary>
        /// Return the error message for the action.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")]
        public String Message { get; set; }

        /// <summary>
        /// Return the status of the project.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public CreationProjectStatus Status { get; set; }

        /// <summary>
        /// If you specified 'new' as one or more value in 'privateKey' parameter, the new created keys are returned.
        /// </summary>
        /// <value>
        /// The new keys.
        /// </value>
        [DataMember(Name = "new_keys")]
        public List<String> NewKeys { get; set; }

        #region Private

        [DataMember(Name = "status")]
        private String StatusString
        {
            get
            {
                return Status.ToString();
            }
            set
            {
                Status = (CreationProjectStatus)Enum.Parse(typeof(CreationProjectStatus), value, true);
            }
        }

        #endregion Private
    }
}
