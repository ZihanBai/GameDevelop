//
//  OptionLayer.h
//  FlappyBird
//
//  Created by baizihan on 4/5/15.
//
//

#ifndef __FlappyBird__OptionLayer__
#define __FlappyBird__OptionLayer__

#include "cocos2d.h"

using namespace cocos2d;

class OptionDelegate{
public:
    virtual void onTouch() = 0;
};

class OptionLayer : public Layer {
    
public:
    OptionLayer();
    ~OptionLayer();
    virtual bool init();
    CREATE_FUNC(OptionLayer);
    //override
    void onTouchesBegan(const std::vector<Touch*> &touches,Event *event);
    CC_SYNTHESIZE(OptionDelegate*, delegator, Delegator);
};

#endif /* defined(__FlappyBird__OptionLayer__) */
