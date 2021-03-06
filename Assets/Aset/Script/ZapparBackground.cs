using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;

namespace sabirudev
{
    public class ZapparBackground : MonoBehaviour
    {
        [RequireComponent(typeof(Camera))]
        public class ZapparCameraBackground : MonoBehaviour
        {
            private Material m_cameraMaterial = null;

            private bool m_initialised = false;
            private Texture2D m_camTexture = null;
            private Matrix4x4 m_textureMatrix;
            private float[] m_textureMatElements = null;
            private Camera m_backgroundCamera = null;
            private ZapparCamera m_zapparCamera = null;
            private float[] m_camerModel = null;

            public Texture2D GetCameraTexture => m_camTexture;
            public Matrix4x4 GetTextureMatrix => m_textureMatrix;

            private void Awake()
            {
                m_cameraMaterial = new Material(Shader.Find("Zappar/CameraBackgroundShader"));
                if (m_cameraMaterial == null)
                {
                    Debug.LogError("Can't render camera texture: Missing Zappar/CameraBackgroundShader!");
                }
                m_cameraMaterial.mainTexture = Texture2D.blackTexture;
                m_textureMatrix = new Matrix4x4();
                m_textureMatElements = new float[16];
                m_backgroundCamera = GetComponent<Camera>();
                m_zapparCamera = GetComponentInParent<ZapparCamera>();
                m_camerModel = new float[] { 0, 0, 0, 0, 0, 0 };
            }

            void Point(float x, float y)
            {
                GL.TexCoord2(x, y);
                GL.Vertex3(x, y, -1);
            }

#if ZAPPAR_SRP
        private void Start()
        {
            RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
        }

        private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext arg1, Camera arg2)
        {
            if (arg2.depth != -1)
                return;
            m_cameraMaterial.SetPass(0);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.LoadProjectionMatrix(Matrix4x4.Ortho(0, 1, 0, 1, 0, 1));
            GL.Begin(GL.QUADS);
            Point(0, 0);
            Point(0, 1);
            Point(1, 1);
            Point(1, 0);
            GL.End();
            GL.PopMatrix();
        }
#else
            void OnPostRender()
            {
                m_cameraMaterial.SetPass(0);
                GL.PushMatrix();
                GL.LoadIdentity();
                GL.LoadProjectionMatrix(Matrix4x4.Ortho(0, 1, 0, 1, 0, 1));
                GL.Begin(GL.QUADS);
                Point(0, 0);
                Point(0, 1);
                Point(1, 1);
                Point(1, 0);
                GL.End();
                GL.PopMatrix();
            }

#endif
            void Update()
            {
                if (m_cameraMaterial == null || m_zapparCamera == null)
                    return;

                if (!m_initialised)
                {
                    m_initialised = Z.HasInitialized() && m_zapparCamera.CameraHasStarted;
                    return;
                }

                if (m_zapparCamera.CameraSourcePaused) return;

                m_backgroundCamera.projectionMatrix = Z.PipelineProjectionMatrix(ZapparCamera.Instance.GetPipeline, Screen.width, Screen.height, m_backgroundCamera.nearClipPlane, m_backgroundCamera.farClipPlane, ref m_camerModel);

                Z.PipelineCameraFrameTextureMatrix(ZapparCamera.Instance.GetPipeline, ref m_textureMatElements, Screen.width, Screen.height, ZapparCamera.Instance.IsMirrored);

                UpdateTextureMatrix();

                m_cameraMaterial.SetMatrix("_nativeTextureMatrix", m_textureMatrix);

                m_camTexture = Z.PipelineCameraFrameTexture(ZapparCamera.Instance.GetPipeline);
                if (m_camTexture != null)
                    m_cameraMaterial.mainTexture = m_camTexture;

            }

            private void UpdateTextureMatrix()
            {
                m_textureMatrix[0, 0] = m_textureMatElements[0];
                m_textureMatrix[1, 0] = m_textureMatElements[1];
                m_textureMatrix[2, 0] = m_textureMatElements[2];
                m_textureMatrix[3, 0] = m_textureMatElements[3];
                m_textureMatrix[0, 1] = m_textureMatElements[4];
                m_textureMatrix[1, 1] = m_textureMatElements[5];
                m_textureMatrix[2, 1] = m_textureMatElements[6];
                m_textureMatrix[3, 1] = m_textureMatElements[7];
                m_textureMatrix[0, 2] = m_textureMatElements[8];
                m_textureMatrix[1, 2] = m_textureMatElements[9];
                m_textureMatrix[2, 2] = m_textureMatElements[10];
                m_textureMatrix[3, 2] = m_textureMatElements[11];
                m_textureMatrix[0, 3] = m_textureMatElements[12];
                m_textureMatrix[1, 3] = m_textureMatElements[13];
                m_textureMatrix[2, 3] = m_textureMatElements[14];
                m_textureMatrix[3, 3] = m_textureMatElements[15];
            }

            private void OnDestroy()
            {
                m_textureMatElements = null;
#if ZAPPAR_SRP
            RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
#endif
            }
        }
    }
}