//
//  WelcomeScene.h
//  FlappyBird
//
//  Created by baizihan on 4/2/15.
//
//

#ifndef __FlappyBird__WelcomeScene__
#define __FlappyBird__WelcomeScene__

#include "AtlasLoader.h"
#include "WelcomeLayer.h"
#include "BackgroundLayer.h"
#include "cocos2d.h"

using namespace cocos2d;
using namespace std;

class WelcomeScene : public cocos2d::Scene{
public:
    WelcomeScene(void);
    ~WelcomeScene(void);
    virtual bool init();
    CREATE_FUNC(WelcomeScene);
};

#endif /* defined(__FlappyBird__WelcomeScene__) */
