using MateCat.Net.Models;
using System;
using System.Collections.Generic;
using MateCat.Net.Enums;

namespace MateCat.Net
{
    public interface IMateCatApi
    {
        /// <summary>
        /// Ges the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        String BaseUrl { get; }

        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <param name="files">The file(s) to be uploaded.</param>
        /// <param name="projectName">The name of the project you want create.</param>
        /// <param name="sourceLanguage">RFC 5646 language+region Code ( en-US case sensitive ) as specified in W3C standards.</param>
        /// <param name="targetLanguage">RFC 5646 language(s)+region(s) Code(s) as specified in W3C standards. Multiple languages must be comma separated ( it-IT,fr-FR,es-ES case sensitive)</param>
        /// <param name="subject">The subject of the project you want to create.</param>
        /// <param name="useMemoryServer">Identifier for Memory Server <c>false</c> means disabled, <c>true</c> means MyMemory</param>
        /// <param name="useMachineTranslation">Identifier for Machine Translation Service <c>false</c> means disabled, <c>true</c> means get MT from MyMemory)</param>
        /// <param name="privateKey">Private Key(s) for MyMemory. Fill this field with your MyMemory private key if you already have one or set to new to create a new one. Multiple keys must be comma separated. Up to 5 keys allowed.</param>
        /// <param name="segmantationRule">The segmentation rule you want to use to parse your file.</param>
        /// <returns>The metadata for the created project.</returns>
        Project CreateProject(
            IEnumerable<ProjectFile> files,
            String projectName,
            String sourceLanguage,
            String targetLanguage,
            String subject,
            Boolean useMemoryServer = true,
            Boolean useMachineTranslation = true,
            String privateKey = "",
            SegmentationRule segmantationRule = SegmentationRule.General);

        /// <summary>
        /// Creates the project.
        /// </summary>
        /// <param name="files">The file(s) to be uploaded.</param>
        /// <param name="projectName">The name of the project you want create.</param>
        /// <param name="sourceLanguage">RFC 5646 language+region Code ( en-US case sensitive ) as specified in W3C standards.</param>
        /// <param name="targetLanguage">RFC 5646 language(s)+region(s) Code(s) as specified in W3C standards. Multiple languages must be comma separated ( it-IT,fr-FR,es-ES case sensitive)</param>
        /// <param name="subject">The subject of the project you want to create.</param>
        /// <param name="useMemoryServer">Identifier for Memory Server <c>false</c> means disabled, <c>true</c> means MyMemory</param>
        /// <param name="useMachineTranslation">Identifier for Machine Translation Service <c>false</c> means disabled, <c>true</c> means get MT from MyMemory)</param>
        /// <param name="privateKey">Private Key(s) for MyMemory. Fill this field with your MyMemory private key if you already have one or set to new to create a new one. Multiple keys must be comma separated. Up to 5 keys allowed.</param>
        /// <param name="segmantationRule">The segmentation rule you want to use to parse your file.</param>
        /// <returns>The metadata for the created project.</returns>
        Project CreateProject(
            IEnumerable<ProjectFile> files,
            String projectName,
            String sourceLanguage,
            String targetLanguage,
            SupportedSubject subject = SupportedSubject.General,
            Boolean useMemoryServer = true,
            Boolean useMachineTranslation = true,
            String privateKey = "",
            SegmentationRule segmantationRule = SegmentationRule.General);

        /// <summary>
        /// Change the password of a project.
        /// </summary>
        /// <param name="id">The id of the project you want to update.</param>
        /// <param name="oldPassword">The OLD password of the project you want to update.</param>
        /// <param name="newPassword">The NEW password of the project you want to update.</param>
        /// <returns>The result status for the request.</returns>
        Project ChangeProjectPassword(Int32 id, String oldPassword, String newPassword);

        /// <summary>
        /// Retrieve the status of a project in a JSON string.
        /// </summary>
        /// <param name="id">The identifier of the project.</param>
        /// <param name="password">The password associated with the project.</param>
        /// <returns></returns>
        String GetProjectStatusString(Int32 id, String password);

        /// <summary>
        /// Retrieve the status of a project.
        /// </summary>
        /// <param name="id">The identifier of the project.</param>
        /// <param name="password">The password associated with the project.</param>
        /// <returns></returns>
        ProjectStatus GetProjectStatus(Int32 id, String password);
    }
}
