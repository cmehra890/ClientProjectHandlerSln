﻿using ClientProjectHandle_Entities.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Entities.Admin
{
    public class AdminDashboardModel
    {
        public string? ClientID { get; set; } = string.Empty;
        public string? ClientName { get; set; } = string.Empty;
        public string? ClientTypeOfProject { get; set; } = string.Empty;
        public List<DropDownModel> ClientList { get; set; } = [];
        public List<DropDownModel> ClientTypeOfProjectList { get; set; } = [];
        public List<ProjectSubmissionModel> ProjectSubmissions { get; set; } = [];
    }
    public class ProjectSubmissionModel
    {
        public string? ClientID { get; set; } = string.Empty;
        public string? SubmissionID { get; set; } = string.Empty;
        public string? ClientName { get; set; } = string.Empty;
        public string? ClientEmail { get; set; } = string.Empty;
        public string? ClientPhoneNumber { get; set; } = string.Empty;
        public string? ClientProjectStatus { get; set; } = string.Empty;
        public string? ClientProjectSynopsis { get; set; } = string.Empty;
        public string? ClientProjectType { get; set; } = string.Empty;
        public DateTime ProjectSubmissionDate { get; set; } = default;
    }
    public class CommentModel
    {
        public string? CommentID { get; set; } = string.Empty;
        public string? Comment { get; set; } = string.Empty;
        public string? CommentedBy { get; set; } = string.Empty;
        public string? SubmissionID { get; set; } = string.Empty;
        public DateTime CommnetDate { get; set; } = default;
    }
}
