import { Component } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { AsideComponent } from '../../components/aside/aside.component';
import { RouterModule } from '@angular/router';
import { ToolbarComponent } from '../../toolbar/toolbar.component';
import { SidemenuComponent } from '../../components/sidemenu/sidemenu.component';
import { FooterComponent } from '../../components/footer/footer.component';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [HeaderComponent, SidemenuComponent, AsideComponent, RouterModule, ToolbarComponent, RouterModule, FooterComponent],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss'
})
export class MainLayoutComponent {

}
