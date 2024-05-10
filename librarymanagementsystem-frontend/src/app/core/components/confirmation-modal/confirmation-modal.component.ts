import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";


@Component({
  selector: 'app-confirmation-modal',
  standalone: true,
  imports: [],
  templateUrl: './confirmation-modal.component.html',
  styleUrls: ['./confirmation-modal.component.scss']
})
export class ConfirmationModalComponent {

  //import kısmında CommonModule, NgbModule olacak
  // @Input() title!: string;
  // @Input() message!: string;
  // @Input() cancelButtonText!: string;
  // @Input() confirmButtonText!: string;
  
  // constructor(private activeModal: NgbActiveModal) {}

  // confirm() {
  //   // Onay işlemi burada gerçekleştirilir
  //   console.log('Onaylandı.');
  //   // Modalı kapat
  //   this.activeModal.close('confirm');
  // }

  // dismiss() {
  //   // İptal işlemi burada gerçekleştirilir
  //   console.log('İptal edildi.');
  //   // Modalı kapat
  //   this.activeModal.dismiss('cancel');
  // }
}