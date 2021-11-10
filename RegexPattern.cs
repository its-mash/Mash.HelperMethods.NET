using System;
using System.Collections.Generic;
using System.Text;

namespace Mash.HelperMethods.NET
{
    public class RegexPattern
    {
        public const string LinkPattern1 = @"\b(?<![@.,%&#-])(?<protocol>\w{2,10}:\/\/)?((?:\w|\&\#\d{1,5};)[.-]?)+(\.([a-z]{2,15})|(?(protocol)(?:\:\d{1,6})|(?!)))\b(?![@])(\/)?(?:([\w\d\?\-=#:%@&.;])+(?:\/(?:([\w\d\?\-=#:%@&;.])+))*)?(?<![.,?!-])";

        public const string LinkPattern2 = @"(http|ftp|https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])";

        /// <summary>
        /// Extracts http, https, ftp, ip address  links. Also extracts missing protocol links
        /// </summary>
        public const string LinkPattern3 =
            @"(?:(?:https?|ftp|file):\/\/|\b(?:[a-z\d]+\.))(?:(?:[^\s()<>]+|\((?:[^\s()<>]+|(?:\([^\s()<>]+\)))?\))+(?:\((?:[^\s()<>]+|(?:\(?:[^\s()<>]+\)))?\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’]))?";

        public const string absoluteUrlCheckWithOrWithoutScheme = @"^(?:[a-z]+:)?//";
    }
}
