﻿using Orchard.Comments.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Orchard.Comments.Controllers {
    public class HasCommentsDriver : ContentPartDriver<HasComments> {
        protected override DriverResult Display(HasComments part, string displayType) {
            if (part.CommentsShown == false) {
                return null;
            }

            // todo: (heskew) need to be more flexible with displaying parts somehow. e.g. where should the...
            // comment count go in any given skin or what if the skin builder doesn't want the count
            if (displayType.StartsWith("Detail")) {
                //return Combined(
                //    ContentPartTemplate(part, "Parts/Comments.Count").Location("body", "above.5"),
                //    ContentPartTemplate(part, "Parts/Comments.HasComments").Location("body", "below.5"));
                return ContentPartTemplate(part, "Parts/Comments.HasComments").Location("primary", "after.5");
            }

            if (displayType.Contains("Summary")) {
                return ContentPartTemplate(part, "Parts/Comments.Count").Location("meta");
            }

            return ContentPartTemplate(part, "Parts/Comments.Count").Location("primary", "before.5");
        }

        protected override DriverResult Editor(HasComments part) {
            return ContentPartTemplate(part, "Parts/Comments.HasComments").Location("primary", "99");
        }

        protected override DriverResult Editor(HasComments part, IUpdateModel updater) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return ContentPartTemplate(part, "Parts/Comments.HasComments").Location("primary", "99");
        }
    }
}
