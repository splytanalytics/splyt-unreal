#include "SplytAnalyticsPrivatePCH.h"
#include "SplytAnalytics.h"

IMPLEMENT_MODULE( FSplytAnalytics, SplytAnalytics );

void FSplytAnalytics::Init(std::string customer_id, std::string user_id, std::string device_id, std::string context)
{
    this->splyt = splytapi::Init(customer_id, user_id, device_id, context);
}

splytapi::Splyt* FSplytAnalytics::Splyt()
{
    if (this->splyt == NULL) {
        splytapi::SplytResponse response(false);
        response.SetErrorMessage("Splyt has not been initialized yet.");
        response.SetContent(Json::Value::null);
        throw splytapi::splyt_exception(response);
    }

    return this->splyt;
}


void FSplytAnalytics::StartupModule()
{
	// This code will execute after your module is loaded into memory (but after global variables are initialized, of course.)
}


void FSplytAnalytics::ShutdownModule()
{
	// This function may be called during shutdown to clean up your module.  For modules that support dynamic reloading,
	// we call this function before unloading the module.
}
