//
//  AtlasLoader.cpp
//  FlappyBird
//
//  Created by baizihan on 4/1/15.
//
//

#include <stdio.h>
#include "AtlasLoader.h"

//Initializes the shared object to be nullptr
AtlasLoader* AtlasLoader::s_sharedAtlasLoader = NULL;

AtlasLoader* AtlasLoader::getInstance(){
    if (s_sharedAtlasLoader == NULL) {
        s_sharedAtlasLoader = new AtlasLoader();
        
        if (!s_sharedAtlasLoader->init()) {
            delete s_sharedAtlasLoader;
            s_sharedAtlasLoader = NULL;
            CCLOG("Error:could not init s_sharedAtlasLoader Object");
        }
    }
    return s_sharedAtlasLoader;
}

void AtlasLoader::loadAtlas(std::string fileName, cocos2d::Texture2D *texture){
    std::string data = cocos2d::FileUtils::getInstance()->getStringFromFile(fileName);
    size_t pos = data.find_first_of("\n");
    std::string line = data.substr(0,pos);
    data = data.substr(pos + 1);
    Atlas atlas;
    while (line.length() > 0) {
        sscanf(line.c_str(), "%s %d %d %f %f %f %f",
               atlas.name,
               &atlas.width,
               &atlas.height,
               &atlas.startPosition.x,
               &atlas.startPosition.y,
               &atlas.endPosition.x,
               &atlas.endPosition.y);
        atlas.startPosition.x *= 1024;
        atlas.startPosition.y *= 1024;
        atlas.endPosition.x *= 1024;
        atlas.endPosition.y *= 1024;
        //读取下一行
        pos = data.find_first_of("\n");
        line = data.substr(0,pos);
        data = data.substr(pos + 1);
        //fix 1px edge bug
        if (atlas.name == std::string("land")) {
            ++atlas.startPosition.x;
        }
        //use the data to create a SpriteFrame
        cocos2d::Rect rect = cocos2d::Rect(atlas.startPosition.x,atlas.startPosition.y,atlas.width,atlas.height);
        auto spriteFrame = cocos2d::SpriteFrame::createWithTexture(texture, rect);
        _spriteFrames.insert(std::string(atlas.name), spriteFrame);
    }
}









