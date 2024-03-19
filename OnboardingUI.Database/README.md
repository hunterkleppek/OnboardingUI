# Viewing Markdown (`.md`)
This is written in markdown, and can be viewed in Visual Studio 2022 `17.5.*` natively, or with [this extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor2) in earlier versions.  Also, [this extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.MarkdownEditor) is available for earlier VS versions OR Visual Studio Code could be used as well.


# General SSDT Database Project Guidance
Please see general information about the SSDT Database Project within the `~/SSDT/README.md` in our [Developer-Utilities Repo](https://github.com/SECURAInsurance/Developer-Utilities).  This includes information about tooling required, deploying the database (including locally), and how to setup a new project.


# Local Database Deployment & Testing
This project will require the deployment of both the `DisbursementSupport` database included within this solution as well as the `ApplicationConfiguration` [here](https://github.com/SECURAInsurance/SECURAApplicationConfiguration) (see details from `README.md` above on local deployments).  It also requires data within the `ApplicationConfiguration` database for any projects that depend on it by running `Deploy\ApplicationConfiguration.Config.ConfigurationSetting.sql` if available in that project.  Run the `Kestrel - Local` (or other local) configuration to use integrated security for connection to this local database.


# Deployment Commands
Again, see details in `README.md` mentioned above, but here are some commands that are applicable to this project for quick reference:

1) Command prompt location:
    ```
    cd C:\Src\SapiDisbursementSupport\DisbursementSupport.DB\bin\Debug
    ```

1) **Script-ONLY** command to get `TestPublishScript.sql`:
    ```
    SqlPackage /a:script /SourceFile:DisbursementSupport.DB.dacpac /Profile:Deploy.publish.xml /v:DeployType="DEVELOPMENT" /OutputPath:TestPublishScript.sql /TargetConnectionString:"Data Source=DEVDisbursementSupportSQL;Initial Catalog=DisbursementSupport;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False"
    ```

1) **Publish** command:
    ```
    SqlPackage /a:publish /SourceFile:DisbursementSupport.DB.dacpac /Profile:Deploy.publish.xml /v:DeployType="DEVELOPMENT" /TargetConnectionString:"Data Source=DEVDisbursementSupportSQL;Initial Catalog=DisbursementSupport;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False"
    ```