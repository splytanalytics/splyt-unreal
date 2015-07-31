#pragma once

#include "ISplytAnalytics.h"
#include "splyt.h"

class FSplytAnalytics : public ISplytAnalytics
{
public:
    virtual void Init(std::string customer_id, std::string user_id, std::string device_id, std::string context);

    /** IModuleInterface implementation */
    virtual void StartupModule() override;
    virtual void ShutdownModule() override;
};