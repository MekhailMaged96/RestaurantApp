import { LocalizationService } from './services/localization/localization.service';
import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  currentLang;
  /**
   *
   */
  constructor(private translate:TranslateService,private localizationService:LocalizationService) {
    
    this.localizationService.GetLang();
  
  }
}
