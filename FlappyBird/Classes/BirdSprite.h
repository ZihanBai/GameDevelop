//
//  BirdSprite.h
//  FlappyBird
//
//  Created by baizihan on 4/3/15.
//
//

#ifndef __FlappyBird__BirdSprite__
#define __FlappyBird__BirdSprite__

#include "cocos2d.h"
#include "AtlasLoader.h"

using namespace cocos2d;

//设计小鸟的三种状态
typedef enum {
    ACTION_STATE_IDEL,      /* the idle state, wave wing but do not effected by gravity */
    ACTION_STATE_FLY,       /* the fly state, wave wing and be affected by gravity */
    ACTION_STATE_DIE        /* the die state, the bird die in the ground */
}ActionState;

const int BIRD_PRITE_TAG = 10003;   //set bird sprite tag for selecting it in super node

class BirdSprite : public Sprite {
    
public:
    /**
     *  Default constructor
     */
    BirdSprite();
    
    /**
     *  Default distructor
     */
    ~BirdSprite();
    
    /**
     *  获取单例birdsprite
     *
     *  @return a global instance of birdsprite
     */
    static BirdSprite* getInstance();
    
    /**
     Cocos2d construct
     
     :returns: success return true otherwise return false
     */
    bool virtual init();
    
    /**
     *  create && init the bird
     *
     *  @return success return true otherwise return false
     */
    bool createBird();
    
    /**
     *  The bird fly with swing, but do not effected by gravity.
     */
    void idle();
    
    /**
     *  The bird fly drived by player, effected by gravity. need physical support.
     */
    void fly();
    
    /**
     *  The bird die
     */
    void die();
    
protected:
    /**
     *  This method can create a frame animation with the likey name texture.
     *
     *  @param fmt formated frame name
     *  @param count frames count
     *  @param fps  frames persecond
     *
     *  @return
     */
    static cocos2d::Animation* createAnimation(const char *fmt,int count,float fps);
    
    /**
     *  Since this game has three different types of bird
     * this method is just used for choosing which type of bird by random
     */
    void createBirdByRandom();
    
private:
    /**
     *  the private object
     */
    static BirdSprite* shareBirdSprite;
    
    /**
     *  This method change current status. called by fly and idle etc.s
     *
     *  @param state bird state
     *
     *  @return success return true otherwise return false
     */
    bool changeState(ActionState state);
    
    Action* idleAction;
    
    Action* swingAction;
    
    ActionState currentStatus;
    
    /**
     *  the bird name will be created by random
     */
    std::string birdName;
    
    /**
     *  the bird name format depends on the bird name we have rendom created before
     */
    std::string birdNameFormat;
    
    /**
     *  record the first time into the game.
     */
    unsigned int isFirstTime;
    
};

#endif /* defined(__FlappyBird__BirdSprite__) */
