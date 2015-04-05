//
//  BackgroundLayer.h
//  FlappyBird
//
//  Created by baizihan on 4/2/15.
//
//

#ifndef __FlappyBird__BackgroundLayer__
#define __FlappyBird__BackgroundLayer__

#include "cocos2d.h"
#include "AtlasLoader.h"
#include "time.h"
using namespace cocos2d;
using namespace std;

class BackgroundLayer:public Layer{
public:
    BackgroundLayer(void);
    
    ~BackgroundLayer(void);
    
    virtual bool init();
    
    CREATE_FUNC(BackgroundLayer);
    
    static float getLandHeight();
};

#endif /* defined(__FlappyBird__BackgroundLayer__) */
