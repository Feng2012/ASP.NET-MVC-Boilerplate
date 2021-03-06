﻿namespace Boilerplate.Wizard.Features
{
    using System.Threading.Tasks;
    using Boilerplate.Wizard.Services;

    public class OpenGraphFeature : BinaryChoiceFeature
    {
        public OpenGraphFeature(IProjectService projectService)
             : base(projectService)
        {
        }

        public override string Description
        {
            get { return "Adds Open Graph (Facebook) meta tags to the head of the HTML pages to improve the experience when the page is shared on Facebook and other social networks."; }
        }

        public override IFeatureGroup Group
        {
            get { return FeatureGroups.Social; }
        }

        public override string Icon
        {
            get { return "/Boilerplate.Wizard;component/Assets/Open Graph.png"; }
        }

        public override string Id
        {
            get { return "OpenGraph"; }
        }

        public override bool IsDefaultSelected
        {
            get { return true; }
        }

        public override bool IsVisible
        {
            get { return true; }
        }

        public override int Order
        {
            get { return 1; }
        }

        public override string Title
        {
            get { return "Open Graph"; }
        }

        protected override async Task AddFeature()
        {
            await this.ProjectService.EditCommentInFile(this.Id, EditCommentMode.LeaveCodeUnchanged, @"Views\Home\About.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id, EditCommentMode.LeaveCodeUnchanged, @"Views\Home\Contact.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id, EditCommentMode.LeaveCodeUnchanged, @"Views\Home\Index.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id + "-On", EditCommentMode.LeaveCodeUnchanged, @"Views\Shared\_Layout.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id + "-Off", EditCommentMode.DeleteCode, @"Views\Shared\_Layout.cshtml");
        }

        protected override async Task RemoveFeature()
        {
            await this.ProjectService.EditCommentInFile(this.Id, EditCommentMode.DeleteCode, @"Views\Home\About.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id, EditCommentMode.DeleteCode, @"Views\Home\Contact.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id, EditCommentMode.DeleteCode, @"Views\Home\Index.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id + "-On", EditCommentMode.DeleteCode, @"Views\Shared\_Layout.cshtml");
            await this.ProjectService.EditCommentInFile(this.Id + "-Off", EditCommentMode.UncommentCode, @"Views\Shared\_Layout.cshtml");
        }
    }
}
