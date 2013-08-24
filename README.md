wjkTranslateControls
====================

ASP.net controls to use in localized web applications.

<h2>Preamble</h2>
<p style="text-align: center"> <strong>Eine deutsche Version kannst auf unseren  <a href="http://help.thaifarang.net/wjk-Software.wjkTranslateControls.ashx" target="_blank">Wiki-Sits</a> finden. </strong> </p>
<p> It just made me annoyed, always having to make "pull-ups", when I was developing multilingual sites without good tools. Of course, there are the ressouces, but honestly, to work with it makes really no fun. <br />
    I've already started early, dissolve the whole during the term. Unfortunately that was not the answer I liked. Therefore, I have tackled some time ago where the translation starts: on the Controls.<br />
    Why do we handed translate: Quite simply, the translators still afford not what we want.</p>.
In the wjkTranslateControls are based controls that are overwritten, they implement a translation function.
<h4>Translation function you must see very flexible.</h4><br />
<p>
If anyone has interest, so there is no objection that our SQL interface (which we handed translate) is replaced by other methods. It may be remembered that, for example, interfaces to</p>
<ul>
    <li>"Google-" or "Bing-" translators can be implemented;</li>
    <li>the EntityFramework is used;</li>
    <li>other data bases are installed etc.</li> 
</ul> <br />
<h4>There is no limit to the number of languages ​​and the number of entries. Only the database sets the limits.</h4><br />
<strong>The controls are "only" overwritten, you will of course retain all other features in, so they are compatible to all based frameworks, with all CSS-forms, etc.. <br />
</strong> <br />
Also, no one is prevented from expanding to the whole, in our application, for example, a "View Level" is implemented (what it is, is irrelevant at the moment), we have omitted here. For this purpose, the code was extended easily using a property:
<br /><br />

<pre>[Category(&quot;ToTranslate&quot;)] 
[Description(&quot;The enumerable of viewing for.&quot;)] 
[DefaultValue(translator.ViewLevel.All)] 
[Bindable(true)] [Localizable(true)] 
public translator.ViewLevel level 
{ 
	get 
	{ 
		if (ViewState[&quot;ViewLevel&quot;] == null) return translator.ViewLevel.All; 
		return (translator.ViewLevel)ViewState[&quot;ViewLevel&quot;]; 
	} 
	set 
	{ 
		ViewState[&quot;ViewLevel&quot;] = value; 
	} 
}</pre>
<p> The exact technique you can also at the Controls "tConfirmButton" and "tImageButton" look again and understand. </p> 


<h2>Description</h2><br />
<p>
    wjkTranslateControls is all his own, that the authoritative "Text" (and other) property when rendering undergoes a database query. Here, it is determined whether the particular control on the page "abc", with ID "xyz" and the property "123" a text in the language of "ef" is present. The controls are always created in a base language, it is the foundation of later translation (see there). </p>
<p>
    By handling via <strong>"Page", "ControlID" and "Proberty"</strong>, we achieve that the controls can be clearly recognized to have no extra effort when creating. The feature <strong>language</strong> we accesible by "CurrentUICulture.Name.SubString (0.2)", so actually only the language is used. Of course, this could also be another form wall. <br />
    We each control one additional feature brings "<strong id="setPage">setPage</strong>". This was for the "master sites" necessary. Otherwise, any control of the master site would be recognized again for each page and had to be recompiled. Then "Page" maintained for all sides. The feature <strong>must not</strong> be set </p>
<p>
    If we did then use the property "text" this is only exemplary character. All the properties are translated as text in the database are stored and treated equally (see, For example. "NavigateURL" in "tLink" control). </p>
<h4> Then there are three possible answers: </h4><br />

 <ol> <li>
    The corresponding control in the base language exists, but with a <strong>other text</strong>, the text is updated and given back. </li>
    <li>
    The control in the base language or translated language <strong>not exist</strong> in the base language of the text is stored. The original text is returned. </li>
    <li>
    The control in the base language or translated language <strong>exists</strong>, the text from the database is returned.
</li> </ol>

<p>  
The controls are according to relatives of their basic forms, they can be just pulled out of the toolbox on the page as the originals (for which they are unique in Visual Studio is installed (see Installation) In other respects, their application of their originals - with a few exceptions (see below).
    <br />
    Of course, they are also compatible with "bootstrap" and other extensions. </p>
    
<h2> Installation</h2><br />
<p>Simply download the zip file charge at GitHub[en] or on our "<a href="http://help.thaifarang.net/wjk-Software.wjkTranslateControls.ashx" target="_blank">Wiki-Sits[en] and [de]</a>" (it also includes this page). </p>
<p> Unpack it in your projects folder of Visual Studio (Express) 2012. </p>
<p> Open the folder and call the file &quot;..\Visual Studio 2012\Projects\wjkTranslateControls\wjkTranslateControls\<strong>wjkTranslateControls.sln</strong>&quot; in order to load the project. </p>
<p> Press F5 to see if everything runs or errors popping up, also it built in the "bin" folder the file "wjkTranslateControls.dll". Where you need now. </p>
<p> Stop debugging and open the "toolbox". Right-click there on a tab and choose "create a new tab" and name it "wjkTranslateControls". Then you right-click again on the newly created tab and select "Choose Items ...". <br />
    Now a new window appears, where you choose. "Net Framework Components" and go to "Browse" button. Navigate to "wjkTransalateControls" directory and there to "bin\debug" and select the. "Dll" file. Now you must confirm by selecting "OK". <br />
    After this little excursion should now appear in your toolbox the controls. </p>
<p>The aforementioned "DLL" must in all projects by using "Add Reference ..." referred to, in which you use the wjkTranslateControls. </p>
<p> To avoid that the controls are individually registered on all pages, you must in the "Web.config" still make the following entry: </p><br />
<pre>
    &lt;System.web&gt;
        &lt;... &gt;
        &lt;pages controlRenderingCompatibilityVersion="4.0"&gt;
            &lt;Controls&gt;
                <strong>&lt;add tagPrefix="wjk" namespace="wjkTranslateControls" assembly="wjkTranslateControls" /&gt;</strong>
            &lt;/Controls&gt;
        &lt;/pages&gt;
    &lt;/System.web&gt;
</pre> <br />
<p>
    Also, the base language is specified in the "web.config":
</p><br />
<pre>
  &lt;? Xml version = "1.0" encoding="utf-8"&gt;
  &lt;configuration&gt;
    &lt;appSettings&gt;
      <strong>&lt;add key="baseLang" value="en"/&gt;</strong>
      &lt;add key="ValidationSettings:UnobtrusiveValidationMode" value="None" /&gt;
    &lt;/appSettings&gt;
    &lt;...&gt;
  </pre> <br />
  <p>
      Now we have'll take care of the database. As we have already opened the "web.config", we carry this first one there:
  </p><br />
  <pre>
  &lt;...&gt;
&lt;/appSettings&gt;
&lt;connectionStrings&gt;
    &lt;add name="ConnectionString" connectionString="Data Source=[YOUR SQL-SERVER];Initial Catalog=[YOUR DATABASE];User ID=[YOUR DATABASE USER];Password=[YOUR PASSWORD]" providerName="System.Data.SqlClient" /&gt;
&lt;/connectionStrings&gt;
    &lt;system.web&gt;
    &lt;...&gt;
</pre><br />
<p>
    In the project directory to "wjkTranslateControls" you can find the subdirectory "App_Data" and the file "tblRessources.sql" that you've got to perform, where the table should be created. <strong>Not forget to enter the database in the "Use" section of the script.</strong>
</p><br />
<pre>
    USE [- INSERT your database name here -]
    GO

    /****** Object:  Table [dbo].[tblRessources]    Script Date: 08/24/2013 12:08:59 ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[tblRessources](
	    [ID] [bigint] IDENTITY(1,1) NOT NULL,
	    [lang] [nvarchar](10) NULL,
	    [page] [nvarchar](100) NULL,
	    [controlID] [nvarchar](100) NULL,
	    [Property] [nvarchar](50) NULL,
	    [Text] [nvarchar](max) NULL,
	    [CreationDate] [datetime] NULL,
	    [UpdateDate] [datetime] NULL,
        CONSTRAINT [PK_tblRessources] PRIMARY KEY CLUSTERED 
    (
	    [ID] ASC
    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
</pre><br />

<h2>wjkTranslateControls</h2><br

<div id="tLabel" class="pageContent">
    <h3>tLabel</h3>
    <p>This is the real origin of all of our control and there is not much to predict. Only the "Text" property is translated. "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tLabel ID="TLabel1" runat="server" setPage="Site.master" Text="tLabel"&gt;&lt;/wjk:tLabel&gt;<br />
        <wjk:tLabel ID="TLabel1" runat="server" setPage="Site.master" Text="tLabel"></wjk:tLabel><br />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        Text<br />
        setPage (optional)<br />
    </p>
</div>
<hr />
<div id="tButton" class="pageContent">
    <h3>tButton</h3>
    <p>tButton also has only a translation function for text. "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tButton ID="TButton1" runat="server" setPage="Site.master" Text="tButton" /&gt;<br />
        <wjk:tButton ID="TButton1" runat="server" setPage="Site.master" Text="tButton" /><br />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        Text<br />
        setPage (optional)<br />
    </p>
</div>
<hr />
<div id="tLink" class="pageContent">
    <h3>tLink</h3>
    <p> tLink has in addition to the translation function for text also one for "NavigateUrl (href)". It is intended that you possibly can also represent different links in different language areas. "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tLink ID="TLink1" runat="server" NavigateUrl="#" setPage="Site.master" Text="tLink"&gt;&lt;/wjk:tLink&gt;<br />
        <wjk:tLink ID="TLink1" runat="server" NavigateUrl="#" setPage="Site.master" Text="tLink"></wjk:tLink><br />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        Text<br />
        NavigateUrl<br />
        setPage (optional)<br />
    </p>
</div>
<hr />
<div id="tCheckBox" class="pageContent">
    <h3>tCheckBox</h3>
    <p>tCheckBox also has to provide only the translation function for text. "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tCheckBox ID="TCheckBox1" runat="server" setPage="Site.master" Text="tCheckBox" /&gt;<br />
        <wjk:tCheckBox ID="TCheckBox1" runat="server" setPage="Site.master" Text="tCheckBox" />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        Text<br />
        setPage (optional)<br />
    </p>
</div>
<hr />
<div id="tConfirmButton" class="pageContent">
    <h3>tConfirmButton</h3>
    <p> tConfirmButton has much more to offer, it is only translated text. <br />
         Then, there is still the "ConfirmationMessage", i.e. as soon as you insert a text there, this appears when the button is clicked and the user can determine whether to trigger the action or not.<br />
        "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tConfirmButton ID="TConfirmButton1" runat="server" ConfirmationMessage="Go on?" setPage="Site.master" Text="tConfirmButton" /&gt;<br />
        <wjk:tConfirmButton ID="TConfirmButton1" runat="server" ConfirmationMessage="Go on?" setPage="Site.master" Text="tConfirmButton" />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        Text<br />
        setPage (optional)<br />
        <strong>New function:</strong><br />
        ConfirmationMessage (optional)
    </p>
</div>
<hr />
<div id="tImageButton" class="pageContent">
    <h3>tImageButton</h3>
    <p> tImageButton has much more to offer, it is "Alternate text (alt)" and "ImageUrl (src) 'translated. <br />
         Then there's the "ConfirmationMessage" as in "tConfirmButton", ie as soon as you insert a text there, this is displayed and the user can determine whether to trigger the action or not.<br />
        "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tImageButton ID="TImageButton1" runat="server" setPage="Site.master" AlternateText="wjk-logo" ConfirmationMessage="You clicked me. Go on?" ImageUrl="wjk75x75Trans.gif" /&gt;<br />
        <wjk:tImageButton ID="TImageButton1" runat="server" setPage="Site.master" AlternateText="wjk-logo" ConfirmationMessage="You clicked me. Go on?" ImageUrl="wjk75x75Trans.gif" /><br />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        ImageUrl (src)<br />
        AlternateText (alt)<br />
        setPage (optional)<br />
        <strong>New function:</strong><br />
        ConfirmationMessage (optional)
    </p>
</div>
<hr />
<div id="tLinkButton" class="pageContent">
    <h3>tLinkButton</h3>
    <p>tLinkButton knows only the translation of the text. "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;wjk:tLinkButton ID="TLinkButton1" runat="server" setPage="Site.master" Text="tLinkButton"&gt;&lt;/wjk:tLinkButton&gt;<br />
        <wjk:tLinkButton ID="TLinkButton1" runat="server" setPage="Site.master" Text="tLinkButton"></wjk:tLinkButton><br />
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        Text<br />
        setPage (optional)<br />
    </p>
</div>
<hr />
<div id="tTemplateField" class="pageContent">
    <h3>tTemplateField und tBoundField</h3>
    <p>tTemplateField and tBoundField only know the translation of header text. Both "id" and "page" come from the parent control. <br />
       "<a href="#setPage">SetPage</a>" we have explained above.</p>
    <p>
        &lt;asp:GridView ID="GridView1" runat="server"&gt;<br />
            &lt;Columns&gt;<br />
                &lt;wjk:tBoundField HeaderText="BoundField1" NullDisplayText="no Data" setPage="Site.master" /&gt;<br />
                &lt;wjk:tTemplateField HeaderText="TemplateField1" setPage="Site.master"&gt;&lt;ItemTemplate&gt;No data&lt;/&lt;ItemTemplate&gt;&lt;/wjk:tTemplateField&gt;<br />
            &lt;/Columns&gt;
        &lt;/asp:GridView&gt;
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <wjk:tBoundField HeaderText="BoundField1" NullDisplayText="no Data" setPage="Site.master" />
                <wjk:tTemplateField HeaderText="TemplateField1" setPage="Site.master"><ItemTemplate><wjk:tLabel ID="lbl1" runat="server" Text="No data"></wjk:tLabel></ItemTemplate></wjk:tTemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <strong>Changed properties:</strong><br />
        HeaderText<br />
        setPage (optional)<br />
    </p>
</div>

<h2> What still needs to be done </h2<br />
<p> There are many building sites here. Some examples: </p><br />
<div class="panel panel-danger">
    <div class="panel-heading">
        <h3 class="panel-title">Translation tool</h3></div>
    <div class="panel-body">
        Of course still missing a tool that allows the database to be managed. Finally, the basic texts must be translated somewhere once. <br />
        We already have a ready-made tool, but it needs to be adjusted in the coming days. We hasten.
    </div>
</div>
<div class="panel panel-success">
    <div class="panel-heading">
        <h3 class="panel-title">Missing controls</h3></div>
    <div class="panel-body">
        Some important controls are still missing and we would like to add some more functionality. Once we have some time, we will do it.
    </div>
</div>
<div class="panel panel-success">
    <div class="panel-heading">
        <h3 class="panel-title">Code behind</h3></div>
    <div class="panel-body">
        We have also created classes that can be used in the source code. For example: myRessources.getRessource (and so on) <br />
         The're done, they'll just have to be revised, they resort to the same database and managed with the same tool.
    </div>
</div>
<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Tooltips</h3></div>
    <div class="panel-body">
        This is a special building site because the tooltips are managed elsewhere. Who has come up with this(?).
    </div>
</div>
