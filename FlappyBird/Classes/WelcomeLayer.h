//
//  WelcomeLayer.h
//  FlappyBird
//
//  Created by baizihan on 4/4/15.
//
//

#ifndef __FlappyBird__WelcomeLayer__
#define __FlappyBird__WelcomeLayer__

#include "AtlasLoader.h"
#include "SimpleAudioEngine.h"
#include "CCMenuItem.h"
#include "GameScene.h"
#include "time.h"
#include "cocos2d.h"
#include "BirdSprite.h"

using namespace cocos2d;
using namespace CocosDenshion;
using namespace std;

const int START_BUTTON_TAG = 100;

class WelcomeLayer : public Layer {
public:
    WelcomeLayer();
    ~WelcomeLayer();
    virtual bool init();
    CREATE_FUNC(WelcomeLayer);
    
private:
    /**
     *  The start button has been pressed will call this function
     *
     *  @param sender
     */
    void menuStartCallBack(Object* sender);
    
    /**
     *  This method is make the land have a scroll animation
     *
     *  @param dt the distance each scroll
     */
    void scrollLand(float dt);
    
    Sprite* land1;
    Sprite* land2;
    BirdSprite* bird;
};

#endif /* defined(__FlappyBird__WelcomeLayer__) */
