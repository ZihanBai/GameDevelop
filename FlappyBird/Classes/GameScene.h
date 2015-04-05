//
//  GameScene.h
//  FlappyBird
//
//  Created by baizihan on 4/4/15.
//
//

#ifndef __FlappyBird__GameScene__
#define __FlappyBird__GameScene__

#include "cocos2d.h"
#include "BackgroundLayer.h"
#include "GameLayer.h"
#include "StatusLayer.h"
#include "OptionLayer.h"

using namespace cocos2d;

class GameScene:public Scene{
public:
    GameScene();
    
    ~GameScene();
    
    bool virtual init();
    
    void restart();
    
    CREATE_FUNC(GameScene);
};

#endif /* defined(__FlappyBird__GameScene__) */
