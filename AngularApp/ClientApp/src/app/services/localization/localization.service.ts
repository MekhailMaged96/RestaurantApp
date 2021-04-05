import { TranslateService } from '@ngx-translate/core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalizationService {
  
constructor(private translate:TranslateService) { }


  GetLang(){
    let currentLang = localStorage.getItem('lang') || 'en';
    this.translate.use(currentLang);
    return currentLang;
  }

  setLang(lang){
    localStorage.setItem('lang',lang);
    this.translate.use(lang);
  }

  IsArabic(){

    if(localStorage.getItem('lang')=='ar'){
      return true;
    }else{
      return false;
    }
  }
}
