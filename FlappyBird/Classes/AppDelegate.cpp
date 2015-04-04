#include "AppDelegate.h"
#include "HelloWorldScene.h"
#include "LoadingScene.h"

#define kDesignWidth    288
#define kDesignHeight   512

USING_NS_CC;

AppDelegate::AppDelegate() {

}

AppDelegate::~AppDelegate() 
{
}

//if you want a different context,just modify the value of glContextAttrs
//it will takes effect on all platforms
void AppDelegate::initGLContextAttrs()
{
    //set OpenGL context attributions,now can only set six attributions:
    //red,green,blue,alpha,depth,stencil
    GLContextAttrs glContextAttrs = {8, 8, 8, 8, 24, 8};

    GLView::setGLContextAttrs(glContextAttrs);
}

bool AppDelegate::applicationDidFinishLaunching() {
    // initialize director
    auto director = Director::getInstance();
    auto glview = director->getOpenGLView();
    if(!glview) {
        glview = GLViewImpl::createWithRect("FlappyBird", cocos2d::Rect(0,0,kDesignWidth,kDesignHeight));
        director->setOpenGLView(glview);
    }
    
    director->getOpenGLView()->setDesignResolutionSize(kDesignWidth, kDesignHeight, ResolutionPolicy::EXACT_FIT);
    
    this->setResourceSearchResolution();
    
    // turn on display FPS
    director->setDisplayStats(false);

    // set FPS. the default value is 1.0/60 if you don't call this
    director->setAnimationInterval(1.0 / 60);

    // create a scene. it's an autorelease object
    auto scene = LoadingScene::create();

    // run
    director->runWithScene(scene);

    return true;
}

// This function will be called when the app is inactive. When comes a phone call,it's be invoked too
void AppDelegate::applicationDidEnterBackground() {
    Director::getInstance()->stopAnimation();

    // if you use SimpleAudioEngine, it must be pause
    // SimpleAudioEngine::getInstance()->pauseBackgroundMusic();
}

// this function will be called when the app is active again
void AppDelegate::applicationWillEnterForeground() {
    Director::getInstance()->startAnimation();

    // if you use SimpleAudioEngine, it must resume here
    // SimpleAudioEngine::getInstance()->resumeBackgroundMusic();
}

void AppDelegate::setResourceSearchResolution()
{
    std::vector<std::string> paths;
    paths.push_back("fonts");
    paths.push_back("image");
    paths.push_back("sounds");
    FileUtils::getInstance()->setSearchResolutionsOrder(paths);
}
