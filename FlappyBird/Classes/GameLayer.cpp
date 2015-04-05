//
//  GameLayer.cpp
//  FlappyBird
//
//  Created by baizihan on 4/5/15.
//
//

#include "GameLayer.h"

GameLayer::GameLayer(){}

GameLayer::~GameLayer(){}

bool GameLayer::init(){
    if(Layer::init()) {
        //get the origin point of the X-Y axis, and the visiable size of the screen
        Size visiableSize = Director::getInstance()->getVisibleSize();
        Point origin = Director::getInstance()->getVisibleOrigin();
        
        this->gameStatus = GAME_STATUS_READY;
        this->score = 0;
        
        // Add the bird
        this->bird = BirdSprite::getInstance();
        this->bird->createBird();
        PhysicsBody *body = PhysicsBody::create();
        body->addShape(PhysicsShapeCircle::create(BIRD_RADIUS));
        body->setDynamic(true);
        body->setLinearDamping(0.0f);
        body->setGravityEnable(false);
        this->bird->setPhysicsBody(body);
        this->bird->setPosition(origin.x + visiableSize.width*1/3 - 5,origin.y + visiableSize.height/2 + 5);
        this->bird->idle();
        this->addChild(this->bird);
        
        // Add the ground
        this->groundNode = Node::create();
        float landHeight = BackgroundLayer::getLandHeight();
        auto groundBody = PhysicsBody::create();
        groundBody->addShape(PhysicsShapeBox::create(Size(288, landHeight)));
        groundBody->setDynamic(false);
        groundBody->setLinearDamping(0.0f);
        this->groundNode->setPhysicsBody(groundBody);
        this->groundNode->setPosition(144, landHeight/2);
        this->addChild(this->groundNode);
        
        // init land
        this->landSpite1 = Sprite::createWithSpriteFrame(AtlasLoader::getInstance()->getSpriteFrameByName("land"));
        this->landSpite1->setAnchorPoint(Point::ZERO);
        this->landSpite1->setPosition(Point::ZERO);
        this->addChild(this->landSpite1, 30);
        
        this->landSpite2 = Sprite::createWithSpriteFrame(AtlasLoader::getInstance()->getSpriteFrameByName("land"));
        this->landSpite2->setAnchorPoint(Point::ZERO);
        this->landSpite2->setPosition(this->landSpite1->getContentSize().width-2.0f,0);
        this->addChild(this->landSpite2, 30);
        
        shiftLand = schedule_selector(GameLayer::scrollLand);
        this->schedule(shiftLand, 0.01f);
        
        this->scheduleUpdate();
        
        auto contactListener = EventListenerPhysicsContact::create();
        contactListener->onContactBegin = CC_CALLBACK_1(GameLayer::onContactBegin, this);
        this->getEventDispatcher()->addEventListenerWithSceneGraphPriority(contactListener, this);
        
        return true;
    }else{
        return false;
    }
}

bool GameLayer::onContactBegin(EventCustom *event, const PhysicsContact& contact) {
    this->gameOver();
    return true;
}

void GameLayer::scrollLand(float dt){
    this->landSpite1->setPositionX(this->landSpite1->getPositionX() - 2.0f);
    this->landSpite2->setPositionX(this->landSpite1->getPositionX() + this->landSpite1->getContentSize().width - 2.0f);
    if(this->landSpite2->getPositionX() == 0) {
        this->landSpite1->setPositionX(0);
    }
    
    // move the pips
    for (auto singlePip : this->pips) {
        singlePip->setPositionX(singlePip->getPositionX() - 2);
        if(singlePip->getPositionX() < -PIP_WIDTH) {
            singlePip->setTag(PIP_NEW);
            Size visibleSize = Director::getInstance()->getVisibleSize();
            singlePip->setPositionX(visibleSize.width);
            singlePip->setPositionY(this->getRandomHeight());
        }
    }
}

















