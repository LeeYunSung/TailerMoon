using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.InGame {

    public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        private Vector2 defaultPosition;
        public float moveHorizontal;
        public float moveVertical;

        private const float Radius = 100;
        private Vector3 centerPt;

        public void OnBeginDrag(PointerEventData eventData) {
            defaultPosition = transform.localPosition;
            centerPt = new Vector3(defaultPosition.x, defaultPosition.y, 0.0f);
        }

        public void OnDrag(PointerEventData eventData) {
            Vector3 movement = new Vector3(eventData.position.x, eventData.position.y, 0);
            Vector3 offset = movement - centerPt;
            transform.localPosition = centerPt + Vector3.ClampMagnitude(offset, Radius);

            moveHorizontal = transform.localPosition.x - defaultPosition.x;
            moveVertical = transform.localPosition.y - defaultPosition.y;
        }

        public void OnEndDrag(PointerEventData eventData) {
            transform.localPosition = defaultPosition;
            moveHorizontal = moveVertical = 0;
        }
    }
}