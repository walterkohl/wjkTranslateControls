/* ===================================================
 * wjkTranslateControls
 * http://help.thaifarang.net/wjk-software.wjkTranslateControls
 * ===================================================
 * (c) Copyright 2013 Dipl.-Ing. Walter Kohl - wjk-Software(R)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================== */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;

namespace wjkTranslateControls
{
    [DefaultProperty("RequiredFieldValidator")]
    [ToolboxData("<{0}:tRequiredFieldValidator runat=server></{0}:tRequiredFieldValidator>")]
    public class tRequiredFieldValidator : RequiredFieldValidator
    {
        translator trans = new translator();

        [Bindable(true)]
        [Category("ToTranslate")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Set or get the errormessage of the control.")]
        public new string ErrorMessage
        {
            get
            {
                String s = (String)ViewState["ErrorMessage"];
                return ((s == null) ? String.Empty : trans.translate(strPage, strID, "ErrorMessage", strLanguage, s));
            }
            set
            {
                ViewState["ErrorMessage"] = value;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
        }

        public string strLanguage
        {
            get
            {
                if (this.Page == null) { return string.Empty; } else { return Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2); }
            }
        }

        public string strID
        {
            get { return this.ClientID.ToString(); }
        }

        public string strPage
        {
            get
            {
                if (!DesignMode)
                    return this.Page.Request.AppRelativeCurrentExecutionFilePath;
                else return string.Empty;
            }
        }
        [Bindable(true)]
        [Category("ToTranslate")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("If a page must be set.")]
        public string setPage { set; get; }
    }
}

