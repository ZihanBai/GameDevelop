//
//  AtlasLoader.h
//  FlappyBird
//  骨骼资源管理类
//  全局共享类，用于载入资源和通过资源名称获取精灵帧
//
//  Created by baizihan on 4/1/15.
//
//

#ifndef FlappyBird_AtlasLoader_h
#define FlappyBird_AtlasLoader_h

#include "cocos2d.h"

/*
 atlas 文件结构体
 */
typedef struct tag_atlas{
    char name[255];                 // the image's name
    int width;                      // the image's width
    int height;                     // the image's height
    cocos2d::Vec2 startPosition;    // the image's start position
    cocos2d::Vec2 endPosition;       // the image's end position
}Atlas;

/***
 the helper class for loading the resources of atlas.png/atlas.txt
 
 @Note this is a global shared class,just call the getInstance class method to get the object
 ***/
class AtlasLoader{
public:
    /**
     *  get the instance of AtlasLoader
     *
     *  @return the instance of AtlasLoader
     */
    static AtlasLoader* getInstance();
    
    /**
     *  Destroy the instance of AtlasLoader,and will free all memory it takes
     */
    static void destroy();
    
    /**
     *  Load with file name of an atlas and default load the atlas.png to texture
     *
     *  @param fileName filename the name of an atlas file
     *  @note This function load the images sync,so it will delay the main thread.
     */
    void loadAtlas(std::string fileName);
    
    /**
     *  Load with file name of an atlas
     *
     *  @param fileName filename the name of an atlas file
     *  @param texture  texture the Texture2D object,using to create a sprite frame
     * This function load the images sync,so it will delay the main thread.
     * You can call like that: AtlasLoader::getInstance()->loadAtlas("filename", texture);
     */
    void loadAtlas(std::string fileName,cocos2d::Texture2D *texture);
    
    /**
     *  Get the sprite frame with an image name
     *
     *  @param imageName the name of image
     *
     *  @return the sprite frame object related to an image
     */
    cocos2d::SpriteFrame* getSpriteFrame(std::string imageName);
    
protected:
    /**
     *  The default constructor
     */
    AtlasLoader();
    
    /**
     Initializes the instance of AtlasLoader
     * @note When you are porting Cocos2d-x to a new platform, you may need to take care of
     * this method.
     
     :returns: true if succeeded, otherwise false
     */
    virtual bool init();
    
private:
    /**
     *  The singleton pointer of AtlasLoader
     */
    static AtlasLoader* s_sharedAtlasLoader;
    
    /**
     *  The container to store all the sprite frames that has already loaded
     */
    cocos2d::Map<std::string,cocos2d::SpriteFrame*> _spriteFrames;
    
};



#endif
